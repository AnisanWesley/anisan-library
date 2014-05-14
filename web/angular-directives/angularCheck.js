.directive('angularCheck', function () {
    return {
        restrict: 'A',
        template:
      '<h1 class="lead">   '                                                          
    + '    <span class="visible-lg alert alert-info"> Angular is <span ng-show="false" class="text-danger">not</span> working in Large Resolution for Desktop</span>       '
    + '    <span class="visible-md alert alert-success">Angular is <span ng-show="false" class="text-danger">not</span> working in Medium Resolution for Notebook</span>   '
    + '    <span class="visible-sm alert alert-warning"> Angular is <span ng-show="false" class="text-danger">not</span> working in Small Resolution for Tablet</span>     '
    + '    <span class="visible-xs alert alert-danger"> Angular is <span ng-show="false" class="text-danger">not</span> working in Extra-Small Resolution for Phone</span> '
    + '</h1> '
    };
}	
	//Usage:
	//
	//	````html
	//		<div angular-check></div>
	// 	````
