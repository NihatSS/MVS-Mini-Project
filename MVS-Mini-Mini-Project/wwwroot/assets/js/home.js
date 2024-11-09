const sidebarButton = document.querySelector(".navbar-bar-button");
const sidebarCloseButton = document.querySelector(".sidebar-close-button");
const sidebar = document.querySelector(".sidebar");
const body = document.querySelector("body");
sidebarButton.addEventListener("click", function () {
    sidebar.style.display = "block";
})
sidebarCloseButton.addEventListener("click", function () {
    sidebar.style.display = "none";
})

const bigCard = document.querySelectorAll(".big-card");

bigCard.forEach((card, index) => {
    if (index <= 3) {
        card.addEventListener("mouseover", function () {
            document.querySelectorAll(".big-card .card-img img")[index].src = `./assets/img/card${index + 1}.webp`;
            document.querySelectorAll(".card-description")[index].classList.add("disable");
            document.querySelectorAll(".card-description")[index].parentElement.classList.add("p-2");
            document.querySelectorAll(".card-description-icons")[index].classList.remove("disable");
        });

        card.addEventListener("mouseout", function () {
            document.querySelectorAll(".big-card .card-img img")[index].src = `./assets/img/card${index + 1}-2.webp`;
            document.querySelectorAll(".card-description")[index].classList.remove("disable");
            document.querySelectorAll(".card-description-icons")[index].classList.add("disable");
            document.querySelectorAll(".card-description")[index].parentElement.classList.remove("p-2");
        });
    } else {
        card.addEventListener("mouseover", function () {
            document.querySelectorAll(".big-card .card-img .right-images")[index - 4].classList.remove("vis-hidden");
            document.querySelectorAll(".big-card .card-img .right-images")[index - 4].classList.add("vis-visible");
            document.querySelectorAll(".card-description")[index].classList.add("disable");
            document.querySelectorAll(".card-description")[index].parentElement.classList.add("p-2");
            document.querySelectorAll(".card-description-icons")[index].classList.remove("disable");
        });

        card.addEventListener("mouseout", function () {
            document.querySelectorAll(".big-card .card-img .right-images")[index - 4].classList.remove("vis-visible");
            document.querySelectorAll(".big-card .card-img .right-images")[index - 4].classList.add("vis-hidden");
            document.querySelectorAll(".card-description")[index].classList.remove("disable");
            document.querySelectorAll(".card-description-icons")[index].classList.add("disable");
            document.querySelectorAll(".card-description")[index].parentElement.classList.remove("p-2");
        });
    }

});
const cardRightImage = document.querySelectorAll(".big-card .card-img .right-images img");

cardRightImage.forEach((item, index) => {
    item.addEventListener("mouseover", function () {
        var findDiv = this.parentElement.parentElement.parentElement;
        var oldImage = findDiv.querySelector(".main-image").src;
        findDiv.querySelector(".main-image").src = `${item.src}`;
    })
});


const collectionButton = document.querySelector(".navbar-collection-button");
const collectionDropdown = document.querySelector(".collection-dropdown");
collectionButton.addEventListener("mouseover", function () {
    collectionDropdown.style.display = "block";
})
collectionButton.addEventListener("mouseout", function () {
    collectionDropdown.style.display = "none"
})

const productButton = document.querySelector(".navbar-product-button");
const productDropdown = document.querySelector(".product-dropdown");
productButton.addEventListener("mouseover", function () {
    productDropdown.style.display = "block";
})
productButton.addEventListener("mouseout", function () {
    productDropdown.style.display = "none"
})

const homeButton = document.querySelector(".navbar-home-button");
const homeDropdown = document.querySelector(".home-dropdown");
homeButton.addEventListener("mouseover", function () {
    homeDropdown.style.display = "block";
})
homeButton.addEventListener("mouseout", function () {
    homeDropdown.style.display = "none"
})

const megamenuButton = document.querySelector(".navbar-megamenu-button");
const megamenuDropdown = document.querySelector(".megamenu-dropdown");
megamenuButton.addEventListener("mouseover", function () {
    megamenuDropdown.style.display = "block";
})
megamenuButton.addEventListener("mouseout", function () {
    megamenuDropdown.style.display = "none"
})

const featureButton = document.querySelector(".navbar-feature-button");
const featureDropdown = document.querySelector(".feature-dropdown");
featureButton.addEventListener("mouseover", function () {
    featureDropdown.style.display = "block";
})
featureButton.addEventListener("mouseout", function () {
    featureDropdown.style.display = "none"
})

const shortcodeButton = document.querySelector(".navbar-shortcode-button");
const shortcodeDropdown = document.querySelector(".shortcode-dropdown");
shortcodeButton.addEventListener("mouseover", function () {
    shortcodeDropdown.style.display = "block";
})
shortcodeButton.addEventListener("mouseout", function () {
    shortcodeDropdown.style.display = "none"
})

const chevroletButon = document.querySelectorAll(".honda")[1];
const chevrolet = document.querySelector(".chevrolet");
const chevroletPlus = chevroletButon.querySelector(".fa-plus");
const chevroletMinus = chevroletButon.querySelector(".fa-minus");

chevroletButon.addEventListener("mouseover", function () {
    chevrolet.style.display = "block";
    chevroletPlus.classList.add("d-none");
    chevroletMinus.classList.remove("d-none");
});
chevrolet.addEventListener("mouseover", function () {
    chevrolet.style.display = "block";
    chevroletPlus.classList.add("d-none");
    chevroletMinus.classList.remove("d-none");
})
chevrolet.addEventListener("mouseout", function () {
    chevrolet.style.display = "none";
    chevroletPlus.classList.remove("d-none");
    chevroletMinus.classList.add("d-none");
})
chevroletButon.addEventListener("mouseout", function () {

    chevrolet.style.display = "none";
    chevroletPlus.classList.remove("d-none");
    chevroletMinus.classList.add("d-none");

});
const browseCategoriesButton = document.querySelector(".browse-categories-button");
const browseCategoriesDropdown = document.querySelector(".browse-categories-dropdown");
browseCategoriesButton.addEventListener("mouseover",function(){
    browseCategoriesDropdown.style.display ="block";
})
browseCategoriesButton.addEventListener("mouseout",function(){
    browseCategoriesDropdown.style.display = "none";
})
// chevrolet-sidebar-text
// 
// 
// 





