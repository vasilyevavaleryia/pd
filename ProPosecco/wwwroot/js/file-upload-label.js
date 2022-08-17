document.querySelector("#imageFile").onchange = function () {
    document.querySelector("#fileName").textContent = this.files[0].name;
}