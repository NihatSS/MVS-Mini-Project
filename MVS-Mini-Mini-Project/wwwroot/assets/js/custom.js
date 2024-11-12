let cartBtns = document.querySelectorAll(".card-button");

cartBtns.forEach(elem => {
    elem.addEventListener("click", function () {
        let productId = parseInt(this.getAttribute("data-id"));

        fetch(`home/AddProductToBusket?id=${productId}`, {
            method: "POST",
            headers: {
                'Accept': 'application/json, text/plain, */*',
                'Content-Type': 'application/json'
            },
        })
            .then(res => res.json())
            .then(res => {
                document.querySelector(".shopping-text").innerText = `Cart: ${res}`
            })
    });
});


