var angular = angular || {};
angular.module('wiz', [])


    .controller('wizCtrl', function (wizard) {
 
    var wz = this;
    var current="first";
    
    wz.current=function(page) {
        return page==current;
    }
    wz.prev=function () {
        current = wizard.prev();
    }
    wz.next=function () {
        current = wizard.next();
    }
    wz.cantPrev=function(){
        return !wizard.canPrev;
    };
    wz.cantNext=function(){
        return !wizard.canNext;
    };
    wz.isLast=function(){
        return wizard.isLast;
    };
    
    
    
    wizard.setPages([
    'first',
        'page2',
        'page3',
        'page4',
        'last',
    ]);
    
    


})


.factory('wizard',function(){
    
    var _index=0, _last=0, _current=0, pages = 0;
    
    var wiz = {
        setPages:setPages,
        current:current,
        next:next,
        prev:prev
    };
    
    
    Object.defineProperty(wiz,'canNext',{get:function(){
        return _index < _last;
    }})
    Object.defineProperty(wiz,'canPrev',{get:function(){
        return _index > 0;
    }})
    
    Object.defineProperty(wiz,'isLast',{get:function(){
        return _index == _last;
    }})
    
    
    
    function setPages(pages){
        _pages = pages;
        _last = pages.length-1
    }
    
    function current(){
        return _pages[_index];
    }
    function next(){
        return _pages[++_index];
    }
    function prev(){
        return _pages[--_index];
    }
    
    return wiz;
     
 })
;
