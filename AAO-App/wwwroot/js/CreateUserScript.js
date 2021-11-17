// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.


const SlideShow = document.querySelector("#CreateUserForm");

let next = new CustomEvent('next');
let prev = new CustomEvent('prev');

const Slides = [];

let dotContainer = document.querySelector("#DotHolder");

const SlideIndex = SlideShow.querySelectorAll(".Formula").length - 1;

let CurrentSlide = 0;

let dots = [];

SlideShow.querySelectorAll(".Formula").forEach(function (e) {
    Slides.push(e);
});

Slides.forEach(function () {
    let dot = document.createElement('button');
    dot.classList.add("Dot");
    dotContainer.appendChild(dot);
    dots.push(dot);
});

dots[0].classList.add("ActiveDot");

function PrevSlide() {
    if (CurrentSlide > 0) {
        Slides[CurrentSlide].classList.remove("Displayed");
        dots[CurrentSlide].classList.remove("ActiveDot");
        CurrentSlide--;
        Slides[CurrentSlide].classList.add("Displayed");
        dots[CurrentSlide].classList.add("ActiveDot");
    } else if (CurrentSlide == 0) {
        Slides[CurrentSlide].classList.remove("Displayed");
        dots[CurrentSlide].classList.remove("ActiveDot");
        CurrentSlide = SlideIndex;
        Slides[CurrentSlide].classList.add("Displayed");
        dots[CurrentSlide].classList.add("ActiveDot");
    }
}

function NextSlide() {
    if (CurrentSlide < SlideIndex) {
        Slides[CurrentSlide].classList.remove("Displayed");
        dots[CurrentSlide].classList.remove("ActiveDot");
        CurrentSlide++;
        Slides[CurrentSlide].classList.add("Displayed");
        dots[CurrentSlide].classList.add("ActiveDot");
    } else if (CurrentSlide => SlideIndex) {
        Slides[CurrentSlide].classList.remove("Displayed");
        dots[CurrentSlide].classList.remove("ActiveDot");
        CurrentSlide = 0;
        Slides[CurrentSlide].classList.add("Displayed");
        dots[CurrentSlide].classList.add("ActiveDot");
    }
}

