const inputMultiContainer = document.querySelectorAll(".input-multi-container");

inputMultiContainer.forEach((container) => {
    const list = container.querySelector(".input-multi-list");
    const template = container.querySelector("template");
    const buttonPlus = container.querySelector(".input-multi-plus");
    const buttonMinus = container.querySelector(".input-multi-minus");

    buttonPlus.addEventListener("click", (target) => {
        target.preventDefault();
        const templateClone = template.content.cloneNode(true);
        var inputs = templateClone.querySelectorAll(".input-multi-input");

        inputs.forEach((input) => {
            input.id = input.id.replace(0, list.children.length);
            input.name = input.name.replace(0, list.children.length);
        });

        if (list.children.length >= 1) {
            buttonMinus.classList.remove("hidden");
        }

        list.appendChild(templateClone);
        console.log(templateClone);
        var inputs = templateClone.querySelectorAll(".ingridient-input");
    });

    buttonMinus.addEventListener("click", (target) => {
        if (list.children.length <= 2) {
            buttonMinus.classList.add("hidden");
        }

        if (list.children.length >= 1) {
            list.children[list.children.length - 1].remove();
        }
    });
});
