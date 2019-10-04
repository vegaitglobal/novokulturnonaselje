var functions = (function() {
	return {
		//acordion
		accordion: function () {
			$('.accordion .acc-head').on('click', function () {
				if (!$(this).hasClass('selected')) {
					$('.accordion .acc-head').removeClass('selected');
					$('.accordion .acc-content').slideUp().attr('aria-hidden', 'true');
					$(this).addClass('selected');
					$(this).parent().removeAttr('aria-haspopup')
					$(this).next('.acc-content').slideDown().removeAttr('aria-hidden');
				} else {
					$(this).removeClass('selected');
					$(this).parent().attr('aria-haspopup', 'true');
					$(this).next('.acc-content').slideUp().attr('aria-hidden', 'true');
				}
			});
			$('.accordion .acc-item:first').find('.acc-head').click();
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
