// Learn more about F# at http://fsharp.org
// See the 'F# Tutorial' project for more help.

open ErrLog;
open System;
open System.Data.SqlClient;


[<EntryPoint>]
let main argv = 
    ErrLog.settings.apikey <- @"[your api key]";
    
    let PrintHelp  = 
        printfn "1) Display Hello, World!\n\
        2) Print Current ErrLog version\n\
        3) Throw an InvalidCastException\n\
        4) Throw an IndexOutOfBoundsException\n\
        5) Throw an ArgumentException\n\
        6) Throw a NullReferenceException\n\
        7) Throw a SQLException\n\
        or\n\
        q) Quit" 
        ()
   
    let DoHelloWorld () = 
        printfn "Hello, World!"
        ()

    let DoErrLogVersion () = 
        let version = ErrLog.logger.version()
        printfn "ErrLog Version: %s" version
        ()

    let DoInvalidCastException () =
        let ex = new InvalidCastException("You can't cast an int to a string")
        raise ex
        ()

    let DoIndexOutOfBoundsException () =
        let array = [| 1; 2; 3; 4; 5 |]
        array.[5] |> ignore
        ()

    let DoArgumentException () =
        use conn = new System.Data.SqlClient.SqlConnection("This is not a real connection string") 
        conn.Open();
        ()

    let DoNullReferenceException () =
        let ex = new NullReferenceException("You can't do that with Nothing")
        raise ex
        ()

    let DoSQLException () =
        use conn = new System.Data.SqlClient.SqlConnection("Server=server.invalid;Database=doesnt_exist;Trusted_Connection=True;Connection Timeout=1")
        conn.Open();
        ()

    let DoNothing () =        
        ()

    let HandleInput(input : string) =
        match input with
        | "1" -> DoHelloWorld()
        | "2" -> DoErrLogVersion()
        | "3" -> DoInvalidCastException()
        | "4" -> DoIndexOutOfBoundsException()
        | "5" -> DoArgumentException()
        | "6" -> DoNullReferenceException()
        | "7" -> DoSQLException()
        | "q" -> exit(0)
        | _ -> DoNothing()

    let DoStuff () =
        while (true) do
            try 
                PrintHelp
                printf "Enter a selection: ";
                let input  = Console.ReadLine();
                HandleInput(input)
                printfn ""
            with
                | ex -> ErrLog.logger.log ex |> ignore
        ()

    DoStuff()
    0
    