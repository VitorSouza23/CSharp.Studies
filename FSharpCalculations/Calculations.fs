namespace FSharpCalculations

module Calculations = 
    type Quality = 
        | Good
        | Uncertain
        | Bad

    let density (refDensity: double) (vcl: double) = refDensity * vcl

    let quality quality1 quality2 =
        match (quality1, quality2) with
        | (Bad, _) | (_, Bad) -> Bad
        | (Uncertain, _) | (_, Uncertain) -> Uncertain
        | (Good, Good) -> Good


