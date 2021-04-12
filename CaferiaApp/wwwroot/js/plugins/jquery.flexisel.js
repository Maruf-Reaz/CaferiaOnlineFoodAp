(function($){$.fn.flexisel=function(options){var defaults=$.extend({visibleItems:4,itemsToScroll:3,animationSpeed:400,infinite:!0,navigationTargetSelector:null,autoPlay:{enable:!1,interval:5000,pauseOnHover:!0},responsiveBreakpoints:{portrait:{changePoint:480,visibleItems:1,itemsToScroll:1},landscape:{changePoint:640,visibleItems:2,itemsToScroll:2},tablet:{changePoint:768,visibleItems:3,itemsToScroll:3}}},options);var object=$(this);var settings=$.extend(defaults,options);var itemsWidth;var canNavigate=!0;var itemCount;var itemsVisible=settings.visibleItems;var itemsToScroll=settings.itemsToScroll;var responsivePoints=[];var resizeTimeout;var autoPlayInterval;var methods={init:function(){return this.each(function(){methods.appendHTML();methods.setEventHandlers();methods.initializeItems()})},initializeItems:function(){var obj=settings.responsiveBreakpoints;for(var i in obj){responsivePoints.push(obj[i])}
responsivePoints.sort(function(a,b){return a.changePoint-b.changePoint});var childSet=object.children();itemsWidth=methods.getCurrentItemWidth();itemCount=childSet.length;childSet.width(itemsWidth);object.css({'left':-itemsWidth*(itemsVisible+1)});object.fadeIn();$(window).trigger('resize')},appendHTML:function(){object.addClass("nbs-flexisel-ul");object.wrap("<div class='nbs-flexisel-container'><div class='nbs-flexisel-inner'></div></div>");object.find("li").addClass("nbs-flexisel-item");if(settings.navigationTargetSelector&&$(settings.navigationTargetSelector).length>0){$("<div class='nbs-flexisel-nav-left'><i class='material-icons'>chevron_left</i></div><div class='nbs-flexisel-nav-right'><i class='material-icons'>chevron_right</i></div>").appendTo(settings.navigationTargetSelector)}else{settings.navigationTargetSelector=object.parent();$("<div class='nbs-flexisel-nav-left'><i class='material-icons'>chevron_left</i></div><div class='nbs-flexisel-nav-right'><i class='material-icons'>chevron_right</i></div>").insertAfter(object)}
if(settings.infinite){var childSet=object.children();var cloneContentBefore=childSet.clone();var cloneContentAfter=childSet.clone();object.prepend(cloneContentBefore);object.append(cloneContentAfter)}},setEventHandlers:function(){var childSet=object.children();$(window).on("resize",function(event){clearTimeout(resizeTimeout);resizeTimeout=setTimeout(function(){methods.calculateDisplay();itemsWidth=methods.getCurrentItemWidth();childSet.width(itemsWidth);if(settings.infinite){object.css({'left':-itemsWidth*Math.floor(childSet.length/2)})}else{methods.clearDisabled();$(settings.navigationTargetSelector).find(".nbs-flexisel-nav-left").addClass('disabled');object.css({'left':0})}},100)});$(settings.navigationTargetSelector).find(".nbs-flexisel-nav-left").on("click",function(event){methods.scroll(!0)});$(settings.navigationTargetSelector).find(".nbs-flexisel-nav-right").on("click",function(event){methods.scroll(!1)});if(settings.autoPlay.enable){methods.setAutoplayInterval();if(settings.autoPlay.pauseOnHover===!0){object.on({mouseenter:function(){canNavigate=!1},mouseleave:function(){canNavigate=!0}})}}
object[0].addEventListener('touchstart',methods.touchHandler.handleTouchStart,!1);object[0].addEventListener('touchmove',methods.touchHandler.handleTouchMove,!1)},calculateDisplay:function(){var contentWidth=$('html').width();var largestCustom=responsivePoints[responsivePoints.length-1].changePoint;for(var i in responsivePoints){if(contentWidth>=largestCustom){itemsVisible=settings.visibleItems;itemsToScroll=settings.itemsToScroll;break}else{if(contentWidth<responsivePoints[i].changePoint){itemsVisible=responsivePoints[i].visibleItems;itemsToScroll=responsivePoints[i].itemsToScroll;break}else{continue}}}},scroll:function(reverse){if(typeof reverse==='undefined'){reverse=!0}
if(canNavigate==!0){canNavigate=!1;itemsWidth=methods.getCurrentItemWidth();if(settings.autoPlay.enable){clearInterval(autoPlayInterval)}
if(!settings.infinite){var scrollDistance=itemsWidth*itemsToScroll;if(reverse){object.animate({'left':methods.calculateNonInfiniteLeftScroll(scrollDistance)},settings.animationSpeed,function(){canNavigate=!0})}else{object.animate({'left':methods.calculateNonInfiniteRightScroll(scrollDistance)},settings.animationSpeed,function(){canNavigate=!0})}}else{object.animate({'left':reverse?"+="+itemsWidth*itemsToScroll:"-="+itemsWidth*itemsToScroll},settings.animationSpeed,function(){canNavigate=!0;if(reverse){methods.offsetItemsToBeginning(itemsToScroll)}else{methods.offsetItemsToEnd(itemsToScroll)}
methods.offsetSliderPosition(reverse)})}
if(settings.autoPlay.enable){methods.setAutoplayInterval()}}},touchHandler:{xDown:null,yDown:null,handleTouchStart:function(evt){this.xDown=evt.touches[0].clientX;this.yDown=evt.touches[0].clientY},handleTouchMove:function(evt){if(!this.xDown||!this.yDown){return}
var xUp=evt.touches[0].clientX;var yUp=evt.touches[0].clientY;var xDiff=this.xDown-xUp;var yDiff=this.yDown-yUp;if(Math.abs(xDiff)>0){if(xDiff>0){methods.scroll(!1)}else{methods.scroll(!0)}}
this.xDown=null;this.yDown=null;canNavigate=!0}},getCurrentItemWidth:function(){return(object.parent().width())/itemsVisible},offsetItemsToBeginning:function(number){if(typeof number==='undefined'){number=1}
for(var i=0;i<number;i++){object.children().last().insertBefore(object.children().first())}},offsetItemsToEnd:function(number){if(typeof number==='undefined'){number=1}
for(var i=0;i<number;i++){object.children().first().insertAfter(object.children().last())}},offsetSliderPosition:function(reverse){var left=parseInt(object.css('left').replace('px',''));if(reverse){left=left-itemsWidth*itemsToScroll}else{left=left+itemsWidth*itemsToScroll}
object.css({'left':left})},getOffsetPosition:function(){return parseInt(object.css('left').replace('px',''))},calculateNonInfiniteLeftScroll:function(toScroll){methods.clearDisabled();if(methods.getOffsetPosition()+toScroll>=0){$(settings.navigationTargetSelector).find(".nbs-flexisel-nav-left").addClass('disabled');return 0}else{return methods.getOffsetPosition()+toScroll}},calculateNonInfiniteRightScroll:function(toScroll){methods.clearDisabled();var negativeOffsetLimit=(itemCount*itemsWidth)-(itemsVisible*itemsWidth);if(methods.getOffsetPosition()-toScroll<=-negativeOffsetLimit){$(settings.navigationTargetSelector).find(".nbs-flexisel-nav-right").addClass('disabled');return-negativeOffsetLimit}else{return methods.getOffsetPosition()-toScroll}},setAutoplayInterval:function(){autoPlayInterval=setInterval(function(){if(canNavigate){methods.scroll(!1)}},settings.autoPlay.interval)},clearDisabled:function(){var parent=$(settings.navigationTargetSelector);parent.find(".nbs-flexisel-nav-left").removeClass('disabled');parent.find(".nbs-flexisel-nav-right").removeClass('disabled')}};if(methods[options]){return methods[options].apply(this,Array.prototype.slice.call(arguments,1))}else if(typeof options==='object'||!options){return methods.init.apply(this)}else{$.error('Method "'+method+'" does not exist in flexisel plugin!')}}})(jQuery)