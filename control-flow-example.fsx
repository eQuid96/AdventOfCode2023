for i = 1 to 3 do
    printfn $"{i}"
    
for i = 3 downto 1 do
    printfn $"{i}"
    
    
let todos = [ "Learn Function Programming"; "Learn F#"; "Play" ]

for todo in todos do
    printfn $"{todo}"
      
let todoUpper = [for todo in todos do todo.ToUpper()]

open System
let mutable input = ""
while (input <> "q") do
    input <- Console.ReadLine()


let isEven value =
    if value % 2 = 0 then
        true
    else
        false
        
        
isEven 2

let divide x y =
    try
        Some(x / y)
    with
        | :? System.DivideByZeroException -> printfn "Can't divide by zero"; None


// patter matching <3

type Address = {HouseNumber: int; Street: string}
type PhoneNumber = {Code: int; Number: string}

type ContactMethod =
    | PostMail of Address
    | Email of string
    | VoiceMail of PhoneNumber
    
    
let sendMessage (message: string) (method: ContactMethod) =
    match method with
    | PostMail address -> printfn $"Sending post mail to {address.Street}, {address.HouseNumber}"
    | Email mail -> printfn $"Send email to {mail}"
    | VoiceMail phoneNumber -> printfn $"Calling +00{phoneNumber.Code} - {phoneNumber.Number}"
    
    
