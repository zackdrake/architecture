
function funcPayer() {
    document.getElementById('submit').value = 'payer';
}
function funcTransac() {
    document.getElementById('submit').value = 'transaction';
}
function SourceOption(flight) {
    console.log("test")
    console.log(flight.id)
    let option = document.getElementById('options');
    if (source == intern) {
        option.innerHTML = `
            <div name="InternalFlightDiv">
            



            <div name="ChildDiv">
                <label for="Child">Tarif enfant -10ans => -10%</label>
                <input type="checkbox" name="Child" checked value="true" />
                <input type="hidden" name="Child" value="false" />
            </div>
            <div name="LuggageDiv">
                <label for="Luggage">Bagage : 50€</label>
                <input type="checkbox" name="Luggage" checked value="true" />
                <input type="hidden" name="Luggage" value="false" />
            </div>

        </div>
`
    }
    if (source == external) {
        option.innerHTML = `
        <div name="ExternalFlightDiv">
            



            <div name="ChildDiv">
                <label for="Child">Tarif enfant -10ans => -10%</label>
                <input type="checkbox" name="Child" checked value="true" />
                <input type="hidden" name="Child" value="false" />
            </div>
            <div name="LuggageDiv">
                <label for="Luggage">Bagage : 50€</label>
                <input type="checkbox" name="Luggage" checked value="true" />
                <input type="hidden" name="Luggage" value="false" />
            </div>
            <div name="FirstClassDiv">
                <label for="FirstClass">Première Classe : 50€</label>
                <input type="checkbox" name="FirstClass" checked value="true" />
                <input type="hidden" name="FirstClass" value="false" />
            </div>
            <div name="ChampagneOnBoardDiv">
                <label for="ChampagneOnBoard">Champagne : ??€</label>
                <input type="checkbox" name="ChampagneOnBoard" checked value="true" />
                <input type="hidden" name="ChampagneOnBoard" value="false" />
            </div>
            <div name="LoungAccessDiv">
                <label for="LoungeAccess">Acces Lounge : ??€</label>
                <input type="checkbox" name="LoungeAccess" checked value="true" />
                <input type="hidden" name="LoungeAccess" value="false" />
            </div>
        </div >
`
    }
    if (source == broker) {
        option.innerHTML = `
        <div name="ExternalFlightDiv">
            



            <div name="ChildDiv">
                <label for="Child">Tarif enfant -10ans => -10%</label>
                <input type="checkbox" name="Child" checked value="true" />
                <input type="hidden" name="Child" value="false" />
            </div>
            <div name="LuggageDiv">
                <label for="Luggage">Bagage : 50€</label>
                <input type="checkbox" name="Luggage" checked value="true" />
                <input type="hidden" name="Luggage" value="false" />
            </div>
            <div name="FirstClassDiv">
                <label for="FirstClass">Première Classe : 50€</label>
                <input type="checkbox" name="FirstClass" checked value="true" />
                <input type="hidden" name="FirstClass" value="false" />
            </div>
            <div name="ChampagneOnBoardDiv">
                <label for="ChampagneOnBoard">Champagne : ??€</label>
                <input type="checkbox" name="ChampagneOnBoard" checked value="true" />
                <input type="hidden" name="ChampagneOnBoard" value="false" />
            </div>
            <div name="LoungAccessDiv">
                <label for="LoungeAccess">Acces Lounge : ??€</label>
                <input type="checkbox" name="LoungeAccess" checked value="true" />
                <input type="hidden" name="LoungeAccess" value="false" />
            </div>
        </div >
            `
    }

}


