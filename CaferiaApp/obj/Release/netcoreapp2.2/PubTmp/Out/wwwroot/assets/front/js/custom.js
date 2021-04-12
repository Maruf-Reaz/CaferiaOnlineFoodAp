// caferia custom script
//// caferia custom script
//sessionStorage.clear();
//var keepProductId = $('#productId').val();
//sessionStorage.setItem('productId', keepProductId);
//var productId = sessionStorage.getItem('productId');
(function ($) {
    /**/
    toastr.options = {
        "preventDuplicates": true,
        "preventOpenDuplicates": true
    };

    "use strict";
    var caferia = {
        initialised: false,
        version: 1.0,
        mobile: false,
        init: function () {
            if (!this.initialised) {
                this.initialised = true;
            } else {
                return;
            }
            /*-------------- caferia Functions Calling ---------------------------------------------------
            ------------------------------------------------------------------------------------------------*/
            this.blog_slider();
            this.testimonial_slider();
            this.blog_single_slider();
            this.search_popup();
            this.scroll_btn();
            this.fd_steps();
            this.fd_datepicker();
            this.fd_timepicker();
            this.fd_forgotpass();
            this.fd_blog_popup();
            this.fd_cartbox_open();
        },
        /*-------------- caferia Functions definition ---------------------------------------------------
        ---------------------------------------------------------------------------------------------------*/
        blog_slider: function () {
            var swiper = new Swiper('.fd_blog_slider .swiper-container', {
                slidesPerView: 3,
                spaceBetween: 30,
                speed: 800,
                loop: false,
                pagination: {
                    el: '.swiper-pagination',
                    clickable: true,
                },
                breakpoints: {
                    800: {
                        slidesPerView: 1,
                        spaceBetween: 20
                    },
                    // when window width is <= 640px
                    1000: {
                        slidesPerView: 2,
                        spaceBetween: 30
                    }
                }
            });
        },
        testimonial_slider: function () {
            var swiper = new Swiper('.fd_testimonial_wrapper .swiper-container', {
                slidesPerView: 1,
                spaceBetween: 30,
                loop: false,
                speed: 800,
                // autoplay: {
                // delay: 2000,
                // },
            });
        },
        blog_single_slider: function () {
            var swiper = new Swiper('.fd_blog_post_slider .swiper-container', {
                slidesPerView: 1,
                spaceBetween: 30,
                loop: false,
                speed: 800,
                navigation: {
                    nextEl: '.fd_next',
                    prevEl: '.fd_prev',
                },
            });
        },
        search_popup: function () {
            $('.fd_search>a>span').on('click', function () {
                $(this).closest('.fd_search').children().addClass('fd_show');
                $('.fd_banner_wpapper').addClass('fd_search_show');
            });
            $('.fd_Seardh_box span').on('click', function () {
                $(this).parent().removeClass('fd_show');
                $('.fd_banner_wpapper').removeClass('fd_search_show');
            });
        },
        scroll_btn: function () {
            if ($('.fd_menu').length) {
                // menu scroll
                var speed = 1000;
                // Find links that are #anchors and scroll to them
                $('.fd_menu a[href*="#"]:not([href="#"])').unbind('click.smoothScroll').bind('click.smoothScroll', function (event) {
                    event.preventDefault();
                    $('html, body').animate({ scrollTop: $($(this).attr('href')).offset().top - 120 }, speed);
                });
            }

            $('.fd_toggle').on('click', function () {
                $(this).closest('.fd_right_section').find('.fd_menu').toggleClass('show')
            })
        },
        fd_steps: function () {
            //jQuery time
            var current_fs, next_fs, previous_fs; //fieldsets
            var opacity, scale; //fieldset properties which we will animate
            var animating; //flag to prevent quick multi-click glitches

            $(".next").click(function (fd) {


                // fd.preventDefault();
                if (animating) return false;
                animating = true;

                current_fs = $(this).closest('fieldset');
                next_fs = $(this).closest('fieldset').next();

                //activate next step on progressbar using the index of next_fs
                $("#progressbar li").eq($("fieldset").index(next_fs)).addClass("active");

                //show the next fieldset
                next_fs.show();
                //hide the current fieldset with style
                current_fs.animate({ opacity: 0 }, {
                    step: function (now, mx) {
                        //as the opacity of current_fs reduces to 0 - stored in "now"
                        //1. scale current_fs down to 80%
                        scale = 1 - (1 - now) * 0.2;
                        //2. bring next_fs from the right(50%)
                        //left = (now * 50)+"%";
                        //3. increase opacity of next_fs to 1 as it moves in
                        opacity = 1 - now;
                        current_fs.css({
                            'transform': 'scale(' + scale + ')',
                            'position': 'absolute'
                        });
                        next_fs.css({ 'opacity': opacity });
                    },
                    duration: 800,
                    complete: function () {
                        current_fs.hide();
                        animating = false;
                    },
                    //this comes from the custom easing plugin
                    easing: 'easeInOutBack'
                });

            });

            $(".previous").click(function (fd) {
                fd.preventDefault();
                if (animating) return false;
                animating = true;

                current_fs = $(this).closest('fieldset');
                previous_fs = $(this).closest('fieldset').prev();

                //de-activate current step on progressbar
                $("#progressbar li").eq($("fieldset").index(current_fs)).removeClass("active");

                //show the previous fieldset
                previous_fs.show();
                //hide the current fieldset with style
                current_fs.animate({ opacity: 0 }, {
                    step: function (now, mx) {
                        //as the opacity of current_fs reduces to 0 - stored in "now"
                        //1. scale previous_fs from 80% to 100%
                        scale = 0.8 + (1 - now) * 0.2;
                        //2. take current_fs to the right(50%) - from 0%
                        //left = ((1-now) * 50)+"%";
                        //3. increase opacity of previous_fs to 1 as it moves in
                        opacity = 1 - now;
                        //current_fs.css({'left': left});
                        previous_fs.css({ 'transform': 'scale(' + scale + ')', 'opacity': opacity });
                    },
                    duration: 800,
                    complete: function () {
                        current_fs.hide();
                        animating = false;
                    },
                    //this comes from the custom easing plugin
                    easing: 'easeInOutBack'
                });
            });

            $(".submit").click(function () {
                return false;
            })

        },
        fd_datepicker: function () {
            //$('.fd_date').datepicker();
            $('.fd_date').datepicker({
                startDate: '+d',
                format: 'yyyy-mm-dd',
                //startDate: '+3d',				
                minDate: new Date(),
                autoclose: true

            });
        },
        fd_timepicker: function () {
            $('.fd_time').timepicker();
        },

        fd_forgotpass: function () {
            $('.fd_forgot_password_link').on('click', function () {
                $('.fd_forgot_password').addClass('fd_show');
            });
            $('.fd_close').on('click', function () {
                $('.fd_forgot_password').removeClass('fd_show');
            });
        },
        fd_blog_popup: function () {
            $('.blog_popup_open').on('click', function () {
                $('.fd_blogsigle_popup').addClass('fd_fixed');
            });
            $('.fd_close').on('click', function () {
                $('.fd_blogsigle_popup').removeClass('fd_fixed');
            });
        },
        fd_cartbox_open: function () {
            $('.fd_ring_effect').on('click', function () {
                $(this).closest('.fd_cart_section').toggleClass('fd_open');
            });
            $('.fd_cart_section').click(function (event) {
                event.stopPropagation();
            });
            $('body').on('click', function () {
                $('.fd_cart_section').removeClass('fd_open');
            });

            $('.fd_cookie_message .fd_close').on('click', function () {
                $('body').addClass('cookie_close');
            });

        }

    };
    $(window).scroll(function () {
        var scroll = $(window).scrollTop();
        if (scroll >= 20) {
            //clearHeader, not clearheader - caps H
            //$(".fd_cart_section").addClass("fd_fixed");
            $(".fd_header").addClass("fd_fixed");
            $("body").addClass("fd_fixed_header");
        } else {
            //$(".fd_cart_section").removeClass("fd_fixed");
            $(".fd_header").removeClass("fd_fixed");
            $("body").removeClass("fd_fixed_header");
        }
    });
    $(document).ready(function () {
        caferia.init();

    });
    $(window).on('load', function () {
        $('.grid').isotope({
            // options...
            itemSelector: '.element-item',
            filter: "*"
        });
        $('.fd_filter_menu li').click(function () {
            var selector = $(this).attr('data-filter');

            $('.grid').isotope({
                filter: selector,
            })

            //changing active class with click event
            $('.fd_filter_menu li.active').removeClass('active');
            $(this).addClass('active');
        });


        // custom scroll
        $(".fd_cart_wrapper fieldset,.fd_related_search").mCustomScrollbar();
    });


    //auth.js
    //hang on event of form with id=myform
    $("#signupform").submit(function (e) {

        e.preventDefault();
        var contact = '';
        var name = $('#name').val();
        var email = $('#email').val();
        var password = $('#password').val();
        contact = $('#contacts').val();
        var y, z;
        var pattern = "[a-z0-9._%+-]+@[a-z0-9.-]+\.[a-z]{2,3}$";
        var mobilepattern = /[^0-9]/g;
        y = email.indexOf("@");
        z = email.lastIndexOf(".");
        var error = 0;
        if (name.length == 0) {
            toastr.warning('Name must be required!', '');
            $("#name").focus();
            error++;
        }
        else if (email.length == 0) {
            toastr.warning('Email must be required!', '');
            $("#email").focus();
            error++;
        }
        else if (!email.match(pattern) && mobilepattern.test(email) == true) {
            toastr.warning('Email must be valid!', '');
            $("#email").focus();
            error++;
        } else if ($("#contacts").length > 0 && contact == '' || contact == 0) {
            toastr.warning('Mobile must be required!', '');
            $("#contacts").focus();
            error++;
        } else if ($("#contacts").length > 0 && mobilepattern.test(contact) == true) {
            toastr.warning('mobile must be valid!', '');
            $("#contacts").focus();
            error++;

        } else if ((password.length <= 5) || password.length == 0) {

            toastr.warning('Please enter minimum 6 characters', '')
            $("#password").focus();
            error++;
        }

        if (error == 0) {
            $.ajax({
                type: "POST",
                dataType: 'json',
                url: '/Account/PublicRegister',
                data: {
                    userName: name,
                    password: password,
                    email: email,
                },
                cache: false,
                success: function (result) {
                    if (result == true) {
                        toastr.success('SIgnUp SuccessFull', '');
                        setTimeout(function () {
                            location.reload();
                        }, 1000);
                    }
                    else {
                        toastr.error('Login Failed', '');
                    }

                }
            });
            //$.ajax({
            //    type: "POST",
            //    url: BASE_URL + '/front/auth/signup',
            //    data: {
            //        'user_name': name,
            //        'user_email': email,
            //        'user_pass': password,
            //        'user_mobile': contact

            //    },
            //    dataType: 'json',
            //    success: function (data) {
            //        toastr.success(data.success.msg, '');
            //        setTimeout(function () {
            //            location.reload();
            //        }, 1000);
            //    },
            //    error: function (data) {
            //        var data = JSON.parse(data.responseText);
            //        console.log(data);
            //        if (data.error) {
            //            toastr.error(data.error, '');
            //        } else {
            //            toastr.error(data.error.failed, '');
            //        }
            //    }
            //});
        }

    });


    $("#loginform").submit(function (e) {
        e.preventDefault();


        var userName = $('#lemail').val();
        var password = $('#lpassword').val();
        var rememberMe = $('#fd_check').prop("checked");



        if (userName.length == 0 || userName == 0) {
            toastr.warning('Email or mobile must be required!', '');
            $("#lemail").focus();
            return false;
        } else
            if (password.length == 0) {
                toastr.warning('Password must be required!', '');
                $("#lpassword").focus();
            }
            else {
                $.ajax({
                    type: "POST",
                    dataType: 'json',
                    url: '/Account/PublicLogin',
                    data: {
                        userName: userName,
                        password: password,
                        rememberMe: rememberMe,
                    },
                    cache: false,
                    success: function (result) {
                        if (result == true) {
                            toastr.success('Login SuccessFull', '');
                            setTimeout(function () {
                                location.reload();
                            }, 1000);
                        }
                        else {
                            toastr.error('Login Failed', '');
                        }

                    }
                });
                //$.ajax({
                //    type: "POST",
                //    url: BASE_URL + '/Account/PublicLogin',
                //    data: data,
                //    dataType: 'json',
                //    success: function (data) {
                //        toastr.success(data.success.msg, '');

                //        location.reload();



                //    },
                //    error: function (data) {
                //        var data = JSON.parse(data.responseText);
                //        console.log(data);
                //        if (data.error) {
                //            toastr.error(data.error, '');
                //        } else {
                //            toastr.error(data.failed.msg, '');
                //        }
                //    }
                //});
            }

    });




    $("#formsforget").submit(function (e) {
        e.preventDefault();
        var email = $('#femail').val();

        if (email.length == 0 || email == 0) {
            toastr.warning('Email or Mobile must be required!', '');
            $("#femail").focus();
            return false;
        }
        else {

            $.ajax({
                type: "POST",
                url: BASE_URL + '/front/auth/forgot',
                data: {
                    'user_email': email
                },
                dataType: 'json',
                success: function (data) {
                    toastr.success(data.success.msg, '');
                    setTimeout(function () {
                        location.reload();
                    }, 1000);
                },
                error: function (data) {
                    var data = JSON.parse(data.responseText);
                    //console.log(data);
                    if (data.error) {
                        toastr.error(data.error, '');

                    } else {
                        toastr.error(data.failed.msg, '');

                    }
                }
            });
        }

    });



    $("#resetform").submit(function (e) {
        e.preventDefault();
        var password = $('#rpassword').val();
        var cpassword = $('#rcpassword').val();
        var acctoken = $('#acctoken').val();
        var user_id = $('#user_id').val();

        $.ajax({
            type: "POST",
            url: BASE_URL + 'front/reset_password',
            data: {
                'password': password,
                'cpassword': cpassword,
                'user_otp': acctoken,
                'user_id': user_id
            },
            dataType: 'json',
            success: function (data) {
                toastr.success(data.success.msg, '');
                setTimeout(function () {
                    window.location = BASE_URL;
                }, 2000);
            },
            error: function (data) {
                var data = JSON.parse(data.responseText);
                console.log(data);
                if (data.error) {
                    toastr.error(data.error, '');
                } else {
                    toastr.error(data.failed.msg, '');
                }
            }
        });


    });

    $('.s1').click(function () {
        event.preventDefault();
        activaTab('signin');
    });



    $('#s2').click(function () {
        event.preventDefault();
        activaTab('signup');
    });
    $('#signOutBtn').click(function () {
        event.preventDefault();
        $.ajax({
            type: "POST",
            dataType: 'json',
            url: '/Account/PublicLogOut',

            cache: false,
            success: function (result) {
                if (result == true) {
                    toastr.success('Logged Out', '');
                    setTimeout(function () {
                        location.reload();
                    }, 1000);
                }
                else {
                    toastr.error('LogOut Failed', '');
                }

            }
        });
    });



    $('.profile_user').click(function () {
        event.preventDefault();
        activaTab('user');
    });
    $('.order_history').click(function () {
        event.preventDefault();
        activaTab('order_history');
    });
    $('.wallet_request').click(function () {
        event.preventDefault();
        activaTab('wallet_request');
    });

    $(".fd_down_button,.fd_banner_content .fd_btn").on("click", function () {
        if ($(this).attr("data-target")) {
            var i = $($(this).attr("data-target"))[0].clientHeight;
            $("html,body").animate({
                scrollTop: i
            }, 500)
        }
    });

    $("#contactform").submit(function (e) {

        e.preventDefault();

        var name = $('#cname').val();
        var email = $('#cemail').val();
        var subject = $('#csubject').val();
        var description = $('#cdescription').val();
        var contact = $('#ccontact').val();
        var y, z;

        y = email.indexOf("@");
        z = email.lastIndexOf(".");

        if (name.length == 0) {
            toastr.warning('Name must be required!', '');
            $("#cname").focus();
            return false;
        }
        else if (email.length == 0) {
            toastr.warning('Email must be required!', '');
            $("#cemail").focus();
            return false;
        }
        else if (y < 1 || z < 1 || z + 2 >= email.length) {
            toastr.warning('Not a valid E-mail address !', '');
            $("#cemail").focus();
            return false;
        }
        else if (subject.length == 0) {
            toastr.warning('Subject must be required!', '');
            $("#csubject").focus();
            return false;
        } else if (contact.length == 0) {
            toastr.warning('Contact must be required!', '');
            $("#ccontact").focus();
            return false;
        } else if (description.length == 0) {
            toastr.warning('Message must be required!', '');
            $("#cdescription").focus();
            return false;
        }
        else {
            $.ajax({
                type: "POST",
                dataType: 'json',
                url: '/WalletRequests/SaveContactUs',
                data: {
                    name: name,
                    email: email,
                    subject: subject,
                    phone: contact,
                    message: description,
                },
                cache: false,
                success: function (result) {
                    if (result == true) {
                        toastr.success('Successfully delivered', '');

                    }
                    else {
                        toastr.error('Failed', '');
                    }

                }
            });


        }

    });



    $("#bookingform").submit(function (e) {

        e.preventDefault();

        var booking_date = $('#booking_date').val();
        var booking_time = $('#booking_time').val();
        var bname = $('#bname').val();
        alert(booking_date);
        alert(booking_time);
        //var bemail = $('#bemail').val();
        var bmobille = $('#bmobile').val();
        var bmessage = $('#bmessage').val();
        $.ajax({
            type: "POST",
            dataType: 'json',
            url: '/WalletRequests/SaveReservasion',
            data: {
                reservasionDate: booking_date,
                reservasionTime: booking_time,
                name: bname,
                phone: bmobille,
                message: bmessage,
            },
            cache: false,
            success: function (result) {
                if (result == true) {
                    toastr.success('Successfully Submitted', '');

                }
                else {
                    toastr.error('Failed', '');
                }

            }
        });
        

    });








    // Product Menu getting on click 

    var count = 0;

    $("#isoitem").click(function (event) {
        console.log('testing hello');
        event.preventDefault();
        localStorage.removeItem('cat');
        count = count + 3;

        $.ajax({
            type: "POST",
            url: BASE_URL + "front/get_pro ",
            data: {
                'counts': count
            },
            success: function (response) {
                var $content = $(response);
                $grid = $('.grid').isotope();
                $grid.append($content).isotope('appended', $content);
                $grid.imagesLoaded().progress(function () {
                    $grid.isotope('layout');
                });

            }
        });

    });


    $("#allMenu").click(function (event) {

        $.ajax({
            type: "POST",
            url: BASE_URL + "front/view_more",
            data: { 'search': 'search' },
            success: function (response) {
                $('#changeMore').html(response);
            }
        });

    });

    $("#searchBlog").on('keyup keydown', function () {
        var search = $('#searchBlog').val();
        console.log(search.length);
        if (search.length == 0) {
            $('#searchResult').hmtl(' ');

        } else {
            $.ajax({
                type: "POST",
                url: BASE_URL + "front/blogSearch ",
                data: { 'search': search },
                success: function (response) {
                    $('#searchResult').html(response);
                }
            });
        }
    })

    $("#Submit_info").submit(function (e) {
        var $this = $(this);
        e.preventDefault();
        var name = $('#SDname').val();
        var email = $('#SDemail').val();
        var contact = $('#SDcontact').val();
        var address = $('#SDaddress').val();
        var country = $('#SDcountry').val();
        var city = $('#SDcity').val();
        var pincode = $('#SDpincode').val();
        var state = $('#SDstate').val();
        // var delivery_opt = $('input[name="delivery_type"]:checked').val();

        var y, z;

        y = email.indexOf("@");
        z = email.lastIndexOf(".");

		/* if(delivery_opt == 2){
			
			var pickup_date = $('#pickup_date').val();
			var pickup_time = $('#pickup_time').val();
			
			if (pickup_date.length == 0) {
			toastr.error('Please Select Pickup Date', '');
			//$('#Sub_info ,#pymchse').attr("disabled", "disabled");
			
			$("#pickup_date").focus();
			
			return false;
			
			}else if (pickup_time.length == 0) {
			toastr.warning('Please Select Pickup Time', '');
			//$('#Sub_info ,#pymchse').attr("disabled", "disabled");
			
			$("#pickup_time").focus();
			
			return false;
			}
			
		} */


        if (name.length == 0) {
            toastr.warning('Name must be required!', '');
            $('#Sub_info ,#pymchse').attr("disabled", "disabled");

            $("#SDname").focus();

            return false;
        }
        else if (email.length == 0) {
            toastr.warning('Email must be required!', '');
            $('#Sub_info ,#pymchse').attr("disabled", "disabled");
            $('#pymchse').prop('disabled', true);
            $("#SDemail").focus();

            return false;
        }
        else if (y < 1 || z < 1 || z + 2 >= email.length) {
            toastr.warning('Not a valid e-mail address !', '');
            $('#Sub_info ').attr("disabled", "disabled");
            $('#pymchse').prop('disabled', true);
            $("#SDemail").focus();

            return false;
        }
        else if (contact.length == 0) {
            toastr.warning('Contact must be required!', '');
            $('#Sub_info').attr("disabled", "disabled");
            $('#pymchse').prop('disabled', true);
            $("#SDcontact").focus();

            return false;
        } else if (address.length == 0) {
            toastr.warning('Address must be required!', '');
            $('#Sub_info').attr("disabled", "disabled");
            $('#pymchse').prop('disabled', true);
            $("#SDaddress").focus();

            return false;
        } else if (country.length == 0) {
            toastr.warning('Country must be required!', '');
            $('#Sub_info').attr("disabled", "disabled");
            $('#pymchse').prop('disabled', true);
            $("#SDcountry").focus();

            return false;
        } else if (state.length == 0) {
            toastr.warning('State must be required!', '');
            $('#Sub_info').attr("disabled", "disabled");
            $('#pymchse').prop('disabled', true);;
            $("#SDstate").focus();

            return false;
        } else if (city.length == 0) {
            toastr.warning('City must be required!', '');
            $('#Sub_info').attr("disabled", "disabled");
            $('#pymchse').prop('disabled', true);
            $("#SDcity").focus();

            return false;
        } else if (pincode.length == 0) {
            toastr.warning('Pincode must be required!', '');
            $('#Sub_info').attr("disabled", "disabled");
            $('#pymchse').prop('disabled', true);
            $("#SDpincode").focus();

            return false;
        }
        else {
            var uniqueSessionToken = sessionStorage.getItem('uniqueToken');
            $.ajax({
                type: "POST",
                dataType: 'json',
                url: '/Items/SaveOrder',
                data: {
                    uniqueToken: uniqueSessionToken,
                    name: $('#SDname').val(),
                    email: $('#SDemail').val(),
                    contact: $('#SDcontact').val(),
                    address: $('#SDaddress').val(),
                    country: $('#SDcountry').val(),
                    city: $('#SDcity').val(),
                    state: $('#SDstate').val(),
                    pincode: $('#SDpincode').val(),
                    orderId: $('#orderId').val(),
                },
                cache: false,
                success: function (result) {



                    if (result != null) {


                        next_tab($this);
                        $('#pymchse').prop('disabled', false);
                        $('#orderId').val(result.orderId);
                        $("#walletAmount").text(result.walletBalance);
                    }
                    else {
                        toastr.error('Order Failed', '');
                    }

                }
            });
            //$.ajax({
            //    type: "POST",
            //    url: BASE_URL + '/front/Save_Shipping_info',
            //    data: {
            //        'name': $('#SDname').val(),
            //        'email': $('#SDemail').val(),
            //        'contact': $('#SDcontact').val(),
            //        'address': $('#SDaddress').val(),
            //        'country': $('#SDcountry').val(),
            //        'city': $('#SDcity').val(),
            //        'state': $('#SDstate').val(),
            //        'pincode': $('#SDpincode').val(),
            //        'delivery_type': delivery_opt,
            //    },
            //    success: function (data) {

            //        next_tab($this);
            //        $('#pymchse').prop('disabled', false);

            //    },
            //    error: function (data) {

            //    }
            //});
        }
    });

	/*$("#pre_order_form").submit(function(e) {
		var $this = $('#Submit_info');
		e.preventDefault();
		var pdate= $('#pre_order_date').val();
		var ptime = $('#pre_order_time').val(); 		
		
		if (pdate == '') {
			toastr.warning('Date must be required!', '');
			$("#pre_order_date").focus();
			
		return false;
		}
		else if (ptime=='') {
			toastr.warning('Time must be required!', '');
			$("#pre_order_time").focus();
			
		return false;
		}else{
			$.ajax({
				type: "POST",
				url: BASE_URL + '/front/Confirm_pre_order',
				data: new FormData(this),
				contentType: false,       
				cache: false,             
				processData:false,
				success: function(data)
				{ 	 
						if(data == 0){
					 		toastr.error('Something went wrong! please try again.', ''); 
							 
						}else if(data == 1){
							$('#pre_order_popup').modal('hide');
							next_tab($this);
							$('#pymchse').prop('disabled', false); 
						} 						
					
				} 
			});
		}
	
	
	});*/


    $("#Submit_payment_info").submit(function (e) {
        var $this = $(this);
        e.preventDefault();
        var special_intruction = $('textarea[name="special_instructions"]').val();
        var pay_type = $('input[name="pay_type"]:checked').val();

        var data = '';
        if (typeof pay_type === 'undefined') {
            toastr.warning('Payment mode must be Selected!', '');
            return false;
        }
        else {
            if (pay_type == 1) {
                $.ajax({
                    type: "POST",
                    dataType: 'json',
                    url: '/Items/CheckBalance',
                    data: {
                        orderId: $('#orderId').val(),
                    },
                    cache: false,
                    success: function (result) {

                        if (result == true) {
                            $.ajax({
                                type: "POST",
                                dataType: 'json',
                                url: '/Items/ConfirmOrder',
                                data: {
                                    orderId: $('#orderId').val(),
                                    payType: pay_type,
                                    special_intruction: special_intruction,
                                },
                                cache: false,
                                success: function (result) {

                                    if (result != null) {
                                        var paymentType = '';
                                        if (result.order.orderType == 1) {
                                            paymentType = 'Caferia Wallet';
                                        }
                                        else if (result.order.orderType == 2) {
                                            paymentType = 'Cash on Delivary';
                                        }


                                        data += '<div class="col-md-12 col-sm-12 col-xs-12"></div><div class="col-md-12 col-sm-12 col-xs-12"><div class="fd_padder_bottom30"> <p class="gray">Hello ' + result.order.applicationUser.userName + ',</p><p>Your order will be Shipped. Expect It To be Delivered within 2 hours after your confirmation of order</p> </div> </div><div class="col-md-6 col-sm-12 col-xs-12" ><p class="gray text-capitalize fd_border_heading">shipping address</p> <p>' + result.order.address + ',<br>' + result.order.country + ',<br>' + result.order.state + '<br>' + result.order.city + ', ' + result.order.pincode + ' </p> </div><div class="col-md-6 col-sm-12 col-xs-12"> <p class="gray text-capitalize fd_border_heading">payment</p> <p class="text-capitalize fd_padder_bottom30">' + paymentType + '</p> </div>';
                                        $('#confirmation').html(data);
                                        $('#pymchse').prop('disabled', false);
                                        next_tab($this);
                                    }
                                    else {
                                        toastr.warning('Something went wrong!', '');
                                    }

                                }
                            });
                        }
                        else {
                            toastr.warning('In-sufficent balance', '');
                        }

                    }
                });

            }
            else if (pay_type == 2) {
                $.ajax({
                    type: "POST",
                    dataType: 'json',
                    url: '/Items/ConfirmOrder',
                    data: {
                        orderId: $('#orderId').val(),
                        payType: pay_type,
                        special_intruction: special_intruction,
                    },
                    cache: false,
                    success: function (result) {

                        if (result != null) {
                            var paymentType = '';
                            if (result.order.orderType == 1) {
                                paymentType = 'Caferia Wallet';
                            }
                            else if (result.order.orderType == 2) {
                                paymentType = 'Cash on Delivary';
                            }


                            data += '<div class="col-md-12 col-sm-12 col-xs-12"></div><div class="col-md-12 col-sm-12 col-xs-12"><div class="fd_padder_bottom30"> <p class="gray">Hello ' + result.order.applicationUser.userName + ',</p><p>Your order will be Shipped. Expect It To be Delivered within 2 hours after your confirmation of order</p> </div> </div><div class="col-md-6 col-sm-12 col-xs-12" ><p class="gray text-capitalize fd_border_heading">shipping address</p> <p>' + result.order.address + ',<br>' + result.order.country + ',<br>' + result.order.state + '<br>' + result.order.city + ', ' + result.order.pinCode + ' </p> </div><div class="col-md-6 col-sm-12 col-xs-12"> <p class="gray text-capitalize fd_border_heading">payment</p> <p class="text-capitalize fd_padder_bottom30">' + paymentType + '</p> </div>';
                            $('#confirmation').html(data);
                            $('#pymchse').prop('disabled', false);
                            next_tab($this);
                        }
                        else {
                            toastr.warning('Something went wrong!', '');
                        }

                    }
                });
            }



            //$.ajax({
            //    type: "POST",
            //    url: BASE_URL + '/front/confirmation',
            //    data: {
            //        'pay_type': pay_type,
            //        'spe_instruction': special_intruction,
            //    },
            //    success: function (data) {
            //        $('#confirmation').html(data);
            //        $('#pymchse').prop('disabled', false);
            //        next_tab($this);

            //    },
            //    error: function (data) {

            //    }
            //});
        }
    });

    $("#Apply_coupon_code").submit(function (e) {
        var $this = $(this);
        e.preventDefault();
        //var prodId = $('#citem_ids').val();
        var coupon_code = $('#coupon_code').val();
        if (coupon_code == '') {
            toastr.warning('Please Enter Coupon Code', '');
            return false;
        }
        else {
            $("#apply_btn ").attr("disabled", true);
            $.ajax({
                type: "POST",
                url: BASE_URL + '/front/varify_coupon',
                data: new FormData(this),
                contentType: false,
                cache: false,
                processData: false,
                success: function (data) {
                    obj = JSON.parse(data);
                    if (obj.status == 0) {
                        toastr.error(obj.error, '');
                        $("#apply_btn ").attr("disabled", false);
                    } else if (obj.status == 1) {
                        toastr.success(obj.error, '');
                        $('#apply_coupon').modal('hide');
                        $('#discountamount').text(obj.dicount_amount);
                        var actual_cost = $("#orderamount").text();
                        var final_amount = parseFloat(actual_cost) - parseFloat(obj.dicount_amount);
                        $("#finalamount").html(final_amount);
                        $('#coupon_btn').html('Remove Coupon' + ' <i class="fa fa-times"></i>');
                        $('#coupon_btn').attr('onclick', 'remove_coupon()');
                    } else {
                        toastr.error('Something went wrong! please try again.', '');
                        $("#apply_btn ").attr("disabled", false);
                    }

                }
            });
        }
    });



    $("#submitpayment").click(function () {

        $.ajax({
            type: "POST",
            dataType: 'json',
            url: '/Items/FinalizeOrder',
            data: {

                orderId: $('#orderId').val(),
            },
            cache: false,
            success: function (result) {



                if (result != null) {
                    location.href = '/Home/OrderConfirmed?orderId=' + result.id;
                }
                else {
                    toastr.error('Something went wrong !', '');
                }

            }
        });

        //document.getElementById("submitpayment").submit();
    });
})(jQuery);

//cart.js
onloadCart();
function onloadCart() {
    var tableData = '';
    var uniqueSessionToken = sessionStorage.getItem('uniqueToken');

    $.ajax({
        type: "POST",
        dataType: 'json',
        url: '/Items/GetCartData',
        data: {
            uniqueToken: uniqueSessionToken,
        },
        cache: false,
        success: function (object) {

            $.each(object.cartItems, function (index, item) {

                var subTotal = eval(item.item.price) * eval(item.quantity)

                tableData += '<tr>';

                tableData += '<td class="fd_Product data-th="Product><img src="/files/items/' + item.item.photoName1 + '" No Image" class="img-responsive" width="" height="50px"></td>';
                tableData += '<td data-th="title" class="fd_title">' + item.item.name + '</td>';
                tableData += '<td data-th="Price" class="fd_price">' + item.item.price + '</td>';
                tableData += '<td class="fd_quantity" data-th="Quantity"><a class="btn  btn-sm" href = "javascript:void(0);" onclick = "plus(' + item.id + ');" > <i class="fa fa-plus"></i></a><input class="form-control text-center" value="' + item.quantity + '" type="text" readonly="readonly"><a class="btn  btn-sm" href="javascript:void(0);" onclick="minus(' + item.id + ');  "><i class="fa fa-minus"></i></a></td>';
                tableData += '<td data-th="Subtotal" class="text-center fd_subtotal">BDT ' + subTotal + '</td>';
                tableData += '<td class="actions text-center fd_remove" data-th=""><a class="btn  btn-danger btn-sm" href = "javascript:void(0);" onclick = "remove(' + item.id + ');" > <i class="fa fa-trash-o"></i></a ></td>';
                tableData += "</tr>";
            });

            $("#cart tbody").html(tableData);
            CartTotalItem();
        }
    });
}


function remove(proid) {
    $.ajax({
        type: "POST",
        dataType: 'json',
        url: '/Items/RemoveFromCart',
        data: {
            cartItemId: proid,
        },
        cache: false,
        success: function (result) {
            if (result == false) {

                onloadCart();
            }
            else {
                onloadCart();
            }

        }
    });

    //$.ajax({
    //    url: BASE_URL + "front/remove_ajax_cartitem",
    //    type: "POST",
    //    data: { proRowid: proRowid },
    //    success: function (data) {

    //        $("#cart tbody").html(data);
    //        onloadCart();
    //    },
    //    error: function (data) {

    //    }
    //});


}

function minus(proid) {
    $.ajax({
        type: "POST",
        dataType: 'json',
        url: '/Items/MinusToCart',
        data: {
            cartItemId: proid,
        },
        cache: false,
        success: function (result) {
            if (result == false) {
                toastr.error('Out Of Stock', '');
                onloadCart();
            }
            else {
                onloadCart();
            }

        }
    });
    //$.ajax({
    //    url: BASE_URL + "front/minus_ajax_cart",
    //    type: "POST",
    //    data: { proid: rowid, qty: qty },
    //    success: function (data) {

    //        $("#cart tbody").html(data);
    //        onloadCart();
    //    },
    //    error: function (data) {

    //    }
    //});
}

function plus(proid) {

    $.ajax({
        type: "POST",
        dataType: 'json',
        url: '/Items/PlusToCart',
        data: {
            cartItemId: proid,
        },
        cache: false,
        success: function (result) {
            if (result == false) {
                toastr.error('Out Of Stock', '');
                onloadCart();
            }
            else {
                onloadCart();
            }

        }
    });


    //$.ajax({
    //    url: BASE_URL + "front/add_ajax_cart",
    //    type: "POST",
    //    data: { productid: proid, qty: qty, item_variation: item_variation },
    //    success: function (data) {
    //        if (data == "false") {
    //            toastr.error('Out Of Stock', '');
    //        } else {
    //            $("#cart tbody").html(data);
    //            onloadCart();
    //        }

    //    },
    //    error: function (data) {


    //    }
    //});
}
function CartTotalItem() {
    var tableData = '';
    var uniqueSessionToken = sessionStorage.getItem('uniqueToken');

    $.ajax({
        type: "POST",
        dataType: 'json',
        url: '/Items/GetCartTotalItem',
        data: {
            uniqueToken: uniqueSessionToken,
        },
        cache: false,
        success: function (data) {
            //alert(data['item']);
            $("#carttotal").html(data.cartTotalItem);
            $("#totalamount").text(data.cartTotalAmount);

            $("#orderamount").text(data.cartTotalAmount);
            $("#finalamount").text(data.cartTotalAmount);
            $("#discountamount").text("0");
            if (data.cartTotalItem == 0) {
                $('#cartbutton').attr("disabled", "disabled");
            } else {
                $('#cartbutton').removeAttr("disabled");
            }
        }
    });



    //$.ajax({
    //    url: BASE_URL + "Items/CartTotalItem",
    //    type: "GET",
    //    success: function (data) {

    //        var data = JSON.parse(data);
    //        alert(data['item']);
    //        $("#carttotal").html(data['item']);
    //        $("#totalamount").text(data['amount']);
    //        $("#orderamount").text(data['amount']);
    //        $("#finalamount").text(data['finalamount']);
    //        $("#discountamount").text(data['discount']);
    //        if (data['discount'] == 0) {
    //            $('#coupon_btn').text('Apply Coupon');
    //            $('#coupon_btn').attr('onclick', 'apply_coupon_modal()');
    //        }
    //        if (data['item'] == 0) {
    //            $('#cartbutton').attr("disabled", "disabled");
    //        } else {
    //            $('#cartbutton').removeAttr("disabled");
    //        }
    //    },
    //    error: function (data) {
    //        // alert('refresh'); 
    //    }
    //});

}
function addWithOpt(proid, qty) {
    var radioValue = $("input[name='item_size']:checked").val();
    addCart(proid, qty, radioValue);
    $('#item_option_modal').modal('hide');
}

function addCart(proid, qty, uniqueToken) {

    var uniqueSessionToken = sessionStorage.getItem('uniqueToken');
    if (uniqueSessionToken == null || uniqueSessionToken == "undefined") {
        uniqueSessionToken = uniqueToken;
        sessionStorage.setItem('uniqueToken', uniqueToken);
    }
    $.ajax({
        type: "POST",
        dataType: 'json',
        url: '/Items/AddToCart',
        data: {
            itemId: proid,
            quantity: qty,
            uniqueToken: uniqueSessionToken,
        },
        cache: false,
        success: function (object) {

            if (object.result == true) {
                toastr.success('Added to Cart', '');
                onloadCart();

            }
            else {
                toastr.error('Failed', '');
            }




        }
    });
    //$.ajax({
    //    url: BASE_URL + "front/add_ajax_cart",
    //    type: "POST",
    //    data: { productid: proid, qty: qty, item_variation: item_variation },
    //    success: function (data) {
    //        if (data == "false") {
    //            toastr.error('Out Of Stock', '');
    //        } else {
    //            $("#cart tbody").html(data);
    //            toastr.success('Added To Cart', '');
    //            onloadCart();
    //        }

    //    },
    //    error: function (data) {
    //        // alert('refresh');
    //    }
    //});
}

function activaTab(tab) {
    $('.nav-tabs a[href="#' + tab + '"]').tab('show');
};

$('#fd_user>a.fd_login').on('click', function () {
    $(this).parent().toggleClass('popup_open');
});
$('#fd_user').on('click', function (event) {
    event.stopPropagation();
});
$('body').on('click', function () {
    $('#fd_user').removeClass('popup_open');
});

$('#fd_user .user_icon').on('click', function () {
    $('#fd_user').toggleClass('profile_popup_open');
});
$('#fd_user').on('click', function (event) {
    event.stopPropagation();
});
$('body,.fd_user_close').on('click', function () {
    $('#fd_user').removeClass('profile_popup_open');
});

$('body,#apply_coupon').on('click', function () {
    event.stopPropagation();
});
$('body,#pre_order_popup').on('click', function () {
    event.stopPropagation();
});

var total = 0;
localStorage.removeItem('cat');
function getcatallitem(cat_id) {
    if (localStorage.getItem("cat") == cat_id) {
        // total = total + 3;
        total = 0;
        if (typeof (Storage) !== "undefined") {
            localStorage.setItem("cat", cat_id);
        }
    } else {
        total = 0;
        if (typeof (Storage) !== "undefined") {
            localStorage.setItem("cat", cat_id);
        }
    }

    /* $.ajax({
              type		: "POST",
              url		: BASE_URL + "front/view_more2",
              data		: {	'search': 'search' },
              success	: function(response){
                $('#changeMore').html(response);
               }
        }); */
    $('#tempcat').val(cat_id);

    $.ajax({
        type: "POST",
        url: BASE_URL + "front/get_pro ",
        data: { 'counts': total, 'cat_id': cat_id },
        success: function (response) {
            console.log(response);
            var $content = $(response);
            $grid = $('.grid').isotope();
            $grid.append($content).isotope('appended', $content);
            $grid.imagesLoaded().progress(function () {
                $grid.isotope('layout');
            });
        }
    });
}



var counts = 0;
function isoitem() {
    console.log('testing hello');
    // event.preventDefault();
    localStorage.removeItem('cat');
    counts = counts + 3;

    $.ajax({
        type: "POST",
        url: BASE_URL + "front/get_pro ",
        data: {
            'counts': counts
        },
        success: function (response) {
            var $content = $(response);
            $grid = $('.grid').isotope();
            $grid.append($content).isotope('appended', $content);
            $grid.imagesLoaded().progress(function () {
                $grid.isotope('layout');
            });

        }
    });

}

// blog search getting on keypress 	//





//taking singli block on click blog id//


function singleBlock(id) {
    $('#searchResult').text(' ');

    if (id) {
        $.ajax({
            type: "POST",
            url: BASE_URL + "front/singleBlock ",
            data: { 'blog_id': id },
            success: function (response) {
                $('#blogContent').removeClass('row');
                $('#blogContent').html(response);
            }
        });
    }

}

function submitComment() {
    var Bl_name = $('#Bl_name').val();
    var Bl_id = $('#Bl_id').val();
    var Bl_email = $('#Bl_email').val();
    var Bl_message = $('#Bl_message').val();

    $.ajax({
        type: "POST",
        url: BASE_URL + '/front/submitComment',
        data: {
            'blog_id': Bl_id,
            'email': Bl_email,
            'comment': Bl_message,
            'name': Bl_name
        },
        success: function (data) {
            $("#RecentComment").append(data);
        },
        error: function (data) {
            var data = JSON.parse(data.responseText);
            console.log(data);
            if (data.error) {
                toastr.error(data.error, '');
            } else {
                toastr.error(data.error.failed, '');
            }
        }
    });
}

function getBlogOfCate(cat_id) {
    if (cat_id) {
        $.ajax({
            type: "POST",
            url: BASE_URL + "front/getBlogOfCat ",
            data: { 'category': cat_id, 'status': 1 },
            success: function (response) {
                $('#blogContent').addClass('row');
                $('#blogContent').html(response);
            }
        });
    }
}


$grid = $('.grid').isotope();
$grid.imagesLoaded().progress(function () {
    $grid.isotope('layout');
});





function addlike(id = null, status = null) {
    var ths = $(this);
    if (id) {
        var blog_id = $('#Bl_id').val();
        $('#likebutton' + id).attr("disabled", "disabled");
        $.ajax({
            type: "POST",
            url: BASE_URL + "front/likebutton ",
            data: { 'blog_id': blog_id, 'status': status },
            success: function (response) {
                if (response) {
                    console.log(response);
                    $('#likebutton' + blog_id).html(response);
                    status = (status == 1) ? 0 : 1;

                    document.getElementById('likebutton' + id).setAttribute('onclick', 'addlike(' + id + ', ' + status + ')')

                }

            }
        });
    } else {
        toastr.warning('login required!', '');
    }
}


function filter_front() {
    var data = $('#fb_keyword1').val();
    if (data.length > 2) {
        var url = BASE_URL + "front/filter_front";
        $.post(url, { 'data': data }, function (fb) {
            if (fb == 'empty') {
                $('#result').removeClass('fd_search_result');
            }
            else {

                $('#result').addClass('fd_search_result');
                $('#data_disp').html(fb);
            }

        });
    }
    else {
        $('#result').removeClass('fd_search_result');
    }
}

$(".requ").keypress(function () {
    $('#Sub_info').removeAttr("disabled");
});




function next_tab(thiss) {
    var current_fs, next_fs, previous_fs; //fieldsets
    var opacity, scale; //fieldset properties which we will animate
    var animating; //flag to prevent quick multi-click glitches 

    if (animating)
        return false;

    animating = true;

    current_fs = thiss.closest('fieldset');
    next_fs = thiss.closest('fieldset').next();

    //activate next step on progressbar using the index of next_fs
    $("#progressbar li").eq($("fieldset").index(next_fs)).addClass("active");

    //show the next fieldset
    next_fs.show();
    //hide the current fieldset with style
    current_fs.animate({ opacity: 0 }, {
        step: function (now, mx) {
            //as the opacity of current_fs reduces to 0 - stored in "now"
            //1. scale current_fs down to 80%
            scale = 1 - (1 - now) * 0.2;
            //2. bring next_fs from the right(50%)
            //left = (now * 50)+"%";
            //3. increase opacity of next_fs to 1 as it moves in
            opacity = 1 - now;
            current_fs.css({
                'transform': 'scale(' + scale + ')',
                'position': 'absolute'
            });
            next_fs.css({ 'opacity': opacity });
        },
        duration: 800,
        complete: function () {
            current_fs.hide();
            animating = false;
        },
        //this comes from the custom easing plugin
        easing: 'easeInOutBack'
    });
}

function wallet_request() {
    var phoneNo = $('#walletPhone').val();
    var requestAmount = $('#walletReqAmount').val();
    var transactionId = $('#transactionId').val();
    var remarks = $('#remarks').val();

    if (phoneNo == '')
        toastr.error("Enter Phone Number", '');
    else if (requestAmount == '' || requestAmount == 0)
        toastr.error("Enter Request Amount", '');
    else if (transactionId == '')
        toastr.error("Enter Transaction Id", '');

    else {
        $.ajax({
            type: "POST",
            dataType: 'json',
            url: '/WalletRequests/SaveRequest',
            data: {
                phoneNo: phoneNo,
                requestAmount: requestAmount,
                transactionId: transactionId,
                remarks: remarks,
            },
            cache: false,
            success: function (result) {



                if (result == true) {

                    $('#fd_user').removeClass('profile_popup_open');
                    toastr.success("Wallet request successfully submitted", '');
                    setTimeout(function () {
                        location.reload();
                    }, 2000);

                }
                else {
                    toastr.error('Failed', '');
                }

            }
        });
    }

}


function user_profile() {
    var name = $('#name').val();
    var cno = $('#cno').val();
    var ps = $('#password').val();
    var ps1 = $('#ps1').val();
    var id = $('#id').val();
    var city = $('#city').val();
    var address = $('#address').val();
    var state = $('#state').val();
    var contry = $('#contry').val();
    var pin = $('#pin').val();
    var add = address + '|' + contry + '|' + city + '|' + state + '|' + pin;
    if (name == '')
        toastr.error("Enter Name", '');
    else if (cno == '')
        toastr.error("Enter Contact Number", '');
    else if (ps != '' && ps.length < 6)
        toastr.error("Password is Short", '');
    else {
        if (ps == '') { ps = ps1; }
        $.post(BASE_URL + 'front/user_profile', { 'name': name, 'cno': cno, 'ps': ps, 'id': id, 'add': add }, function (data) {
            if (data.match('1')) {
                $('#fd_user').removeClass('profile_popup_open');
                toastr.success("Profile Successfully Updated", '');
                setTimeout(function () { window.location.href = BASE_URL; }, 2000);



            }
            else
                toastr.error("Profile Not Updated", '');
        })
    }

}

function apply_coupon_modal(item_id = '') {
    $("#apply_btn").attr("disabled", false);
    $('#citem_ids').val(item_id);
    $('#apply_coupon').modal('show');
}

function remove_coupon() {
    var prod_id = 0;
    $.ajax({
        type: "POST",
        url: BASE_URL + '/front/remove_coupon',
        data: { 'prod_id': prod_id },
        success: function (data) {
            obj = JSON.parse(data);
            if (obj.status == 0) {
                toastr.error(obj.error, '');
            } else if (obj.status == 1) {
                toastr.success(obj.error, '');
                var actual_cost = $('#finalamount').html();
                var final_amount = parseFloat(actual_cost) + parseFloat(obj.dicount_amount);
                $('#discountamount').text('0');
                $('#finalamount').text(final_amount);
                $('#coupon_btn').text('Apply Coupon');
                $('#coupon_btn').attr('onclick', 'apply_coupon_modal()');
            } else {
                toastr.error('Something went wrong! please try again.', '');
            }

        }
    });

}


function showItemOption(mainitem_id) {
    if (mainitem_id != '') {
        $.ajax({
            type: "POST",
            url: BASE_URL + '/front/get_itemoptions',
            data: { 'item_id': mainitem_id },
            success: function (data) {
                obj = JSON.parse(data);
                if (obj['status'] == 1) {
                    $('#item_optlist').html(obj['option_list']);
                    $('#item_option_modal').modal('show');
                }
            }
        });
    }
}


$("input[name='delivery_type']").on('change', function () {

    var devlivery_type = $(this).val();
    if (devlivery_type == '1') {
        //$('.pickup_date_time').hide();
        $('#cod_optlist').show();
    } else if (devlivery_type == '2') {
        //$('.pickup_date_time').show();
        $('#cod_optlist').hide();
    }
});






