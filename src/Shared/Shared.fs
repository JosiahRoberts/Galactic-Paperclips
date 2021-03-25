namespace Shared

open System

[<Measure>]
type usdollar

type Marketing = {
    Level: int
    Cost: decimal<usdollar>
}

type Business = {
    Funds: decimal<usdollar>
    Inventory: bigint
    Price: decimal<usdollar>
    Demand: decimal
    Marketing: Marketing
    
}

[<Measure>]
type inch

type Manufacturing = {
    ClipsPerSecond: decimal
    Wire: decimal<inch>
    Cost: decimal
}


type Galaxy = {
    Business: Business
    Manufacturing: Manufacturing
}











type Todo =
    { Id : Guid
      Description : string }

module Todo =
    let isValid (description: string) =
        String.IsNullOrWhiteSpace description |> not

    let create (description: string) =
        { Id = Guid.NewGuid()
          Description = description }

module Route =
    let builder typeName methodName =
        sprintf "/api/%s/%s" typeName methodName

type ITodosApi =
    { getTodos : unit -> Async<Todo list>
      addTodo : Todo -> Async<Todo> }