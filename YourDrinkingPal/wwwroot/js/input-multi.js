const input = document.querySelectorAll(".input-multi");

input.forEach((x) => {
  const buttonPlus = x.querySelector(".input-multi-button-plus");
  const buttonMinus = x.querySelector(".input-multi-button-minus");

  buttonPlus.addEventListener("click", (target) => {
    target.preventDefault();
    const clone = x.querySelector("template").content.cloneNode(true);
    const list = x.querySelector(".input-multi-list");
    const listChildren = list.children;
    const inputs = list.querySelectorAll(".input-multi-input");
    const inputsClone = clone.querySelectorAll(".input-multi-input");
    var cloneCounter = clone.querySelector(".input-multi-counter");

    if (listChildren.length === 1) {
      buttonMinus.classList.toggle("visually-hidden");
    }
    inputs.forEach((input) => {
      // input.disabled = true;
    });

    inputsClone.forEach((input) => {
      input.id = input.id.replace(0, listChildren.length);
      input.name = input.name.replace(0, listChildren.length);
    });

    if (cloneCounter) {
      cloneCounter.innerHTML = listChildren.length + 1;
    }

    list.appendChild(clone);
  });

  buttonMinus.addEventListener("click", (target) => {
    target.preventDefault();
    const list = x.querySelector(".input-multi-list").children;
    if (list.length > 1) {
      var lastElement = list[list.length - 1];
      var secondLastElement = list[list.length - 2];
      lastElement.remove();
      secondLastElement
        .querySelectorAll(".input-multi-input")
        .forEach((input) => {
          input.disabled = false;
        });
    }

    if (list.length < 2) buttonMinus.classList.toggle("visually-hidden");
  });
});
