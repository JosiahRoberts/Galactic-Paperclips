namespace Shared

open System

[<Measure>]
type usdollar

type Marketing = {
    Level: int
    Cost: decimal<usdollar>
}

module Marketing = 
    let init () = {
        Level = 1
        Cost = 0.25m<usdollar>
    }

type Business = {
    Funds: decimal<usdollar>
    Inventory: int64
    Price: decimal<usdollar>
    Marketing: Marketing
    
}

module Business = 
    let init () = {
        Funds = 1.00m<usdollar>
        Inventory = 0L
        Price = 0.25m<usdollar>
        Marketing = Marketing.init ()
    }

[<Measure>]
type inch

type Manufacturing = {
    ClipsPerSecond: decimal
    Wire: decimal<inch>
    Cost: decimal<usdollar>
}

module Manufacturing =
    let init () = {
        ClipsPerSecond = 1.0m
        Wire = 1000.0m<inch>
        Cost = 1.0m<usdollar>
    }

type Galaxy = {
    Business: Business
    Manufacturing: Manufacturing
    Demand: decimal
}

module Galaxy =
    let init () = {
        Business = Business.init ()
        Manufacturing = Manufacturing.init ()
        Demand = 1.0m
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