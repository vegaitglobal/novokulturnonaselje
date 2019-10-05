$(function(){

	functions.languageSwitcher();
	functions.mobileNavInit();
	functions.stickyHeader();
	functions.heroSlider();
	functions.contributorsSlider();

});

$(window).on('load', function() {

	console.log('window loaded');

});

$(window).on('scroll', function () {

	functions.stickyHeader();

});

$(window).resize(function(){

	console.log('window resized');

});