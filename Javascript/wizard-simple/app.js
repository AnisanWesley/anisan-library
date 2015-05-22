(function(angular) {

    wizardFactory.$inject = [];

    angular.module('nddPrint')
        .factory('wizardFactory', wizardFactory);
    
    function wizardFactory() {
        var index = 0, last = 0, pages;

        var wiz = {
            setPages: setPages,
            current: current,
            setCurrent: setCurrent,
            next: next,
            prev: prev
        };


        Object.defineProperty(wiz, 'canNext', {
            get: function() {
                return index < last;
            }
        });
        Object.defineProperty(wiz, 'canPrev', {
            get: function() {
                return index > 0;
            }
        });

        Object.defineProperty(wiz, 'isLast', {
            get: function() {
                return index == last;
            }
        });

        function setPages(initialPages) {
            pages = initialPages;
            last = pages.length - 1;
            pages[0].visited = true;
        }

        function current() {
            return pages[index].id;
        }

        function setCurrent(step) {
            var indexOf = pages.indexOf(step);
            if (step.visited)
                index = indexOf;
           else if ((pages[indexOf - 1].visited))
                return next();
            return current();
        }
        function next() {
            var step = pages[++index];
            step.visited = true;
            return step.id;
        }
        function prev() {
            return pages[--index].id;
        }

        return wiz;

    }


}(window.angular))