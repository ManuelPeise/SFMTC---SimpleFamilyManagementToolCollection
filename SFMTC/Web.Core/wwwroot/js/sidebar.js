let sidebartoggle = document.querySelector("#sidebarToggle");

sidebartoggle.addEventListener("click", function () {
  document.querySelector("body").classList.toggle("active");
  document.querySelector("#sidebarToggle").classList.toggle("active");
});

let navElements = document.getElementsByClassName(".navigation-list-item");

navElements.forEach((element) => {
  console.log(element);
});
