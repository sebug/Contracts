module FContracts

open System

type Date = Date of DateTime

type Currency = CHF | EUR

type Contract =
    | One of Currency
    | Zero
    | Give of Contract
    | And of Contract * Contract


let date (ds: string): Date option =
    let couldParse,parsedDate = DateTime.TryParse(ds)
    if couldParse then
        Some <| Date parsedDate
    else
        None

let zero: Contract =
    Zero

type Days = double

let diff (d1: Date) (d2: Date): Days =
    match (d1,d2) with
        | (Date dt1,Date dt2) -> (dt2 - dt1).TotalDays

let add (date: Date) (days: Days): Date =
    match date with
        | (Date date) -> Date (date.AddDays(days))

let cand (c1: Contract) (c2: Contract): Contract =
    And (c1,c2)

let give (c: Contract): Contract =
    Give c

let andGive (c: Contract) (d: Contract): Contract =
    cand c <| give d

