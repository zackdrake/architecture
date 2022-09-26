
function funcPayer() {
    document.getElementById('submit').value = 'payer';
}
function funcTransac() {
    document.getElementById('submit').value = 'transaction';
}
function SourceOption(source) {
    console.log("test")
    let option = document.getElementById('options');
    option.innerHTML = '<div><label for="Child">Tariffeeeeee enfant -10ans => -10%</label><input type="checkbox" name="Child" checked value="true" <input type="hidden" name="Child" value="false" /></div >'
}


