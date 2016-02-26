//Name: Hassan Mohammad Adel
//ID: 20120154

let getRandom() : int =
    (new System.Random()).Next(1, 26)

let getAscii char : int = 
    char

let encrypt str key : string =
    let list = str |> Seq.map int
    //Seq.iter(fun x -> printfn "%d" x) list
    let shiftedList = list |> Seq.map(fun x -> if x <> 32 then ((x - 65 + key) % 26 + 65) else 32)
    //Seq.iter(fun x -> printfn "%d" x) shiftedList
    let encryptedStr = shiftedList |> Seq.map char
    //Seq.iter(fun x -> printfn "%c" x) encryptedStr

    System.String.Concat(encryptedStr)

let decrypt str =
    //use file = System.IO.File.CreateText("decryptions.txt")
    for i = 1 to 26 do
        let list = str |> Seq.map int
        let shiftedList = list |> Seq.map(fun x -> if x <> 32 then ((x - 65 + (26-i)) % 26 + 65) else 32)
        let decryptedStrChars = shiftedList |> Seq.map char
        let decryptedStr = System.String.Concat(decryptedStrChars)
        //file.WriteLine(decryptedStr)
        printfn "%s" decryptedStr


[<EntryPoint>]
let main argv = 

    //let str = System.IO.File.ReadAllText("sample.txt")
    let str = "WELCOME ALL"
    let enc = encrypt str (getRandom())
    let dec = decrypt enc

    System.Console.ReadKey() |> ignore
    0 // return an integer exit code
