var functions = (function() {
	return {
		languageSwitcher: function () {
			$('.js-selected-item').on('click', function () {
				if (!$(this).hasClass('open')) {
					$(this).addClass('open');
					$(this).next('.js-language-list').stop().slideDown();
				} else {
					$(this).removeClass('open');
					$(this).next('.js-language-list').stop().slideUp();
				}
			});
		},

		heroSlider: function () {
			$('.js-her-banner-slider').slick({
				infinite: true,
				slidesToShow: 1,
				slidesToScroll: 1,
				dots: true,
				arrows: false
			});
		}
	}
}());
