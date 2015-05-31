/// <reference path="../src/navigation.d.ts" />

// Configuration
Navigation.StateInfoConfig.build([
	{ key: 'home', initial: 'page', states: [
		{ key: 'page', route: '' }
	]},
	{ key: 'person', initial: 'list', states: [
		{ key: 'list', route: 'people/{page}', transitions: [
			{ key: 'select', to: 'details' }
		], defaults: { page: 1 }, trackCrumbTrail: false },
		{ key: 'details', route: 'person/{id}', defaultTypes: { id: 'number' } }
	]}
]);

// StateInfo
var dialogs = Navigation.StateInfoConfig.dialogs;
var home = dialogs['home'];
var homePage = home.states['page'];
var homeKey = home.key;
var homePageKey = homePage.key;
homePage = home.initial;
var person = dialogs['person'];
var personList = person.states['list'];
var personDetails = person.states['details'];
var personListSelect = personList.transitions['select'];
personList = personListSelect.parent;
personDetails = personListSelect.to;
var pageDefault = personList.defaults.page;
var idDefaultType = personDetails.defaultTypes.id;

// Navigation Events
Navigation.StateController.onNavigate((oldState, state, data) => {
	var oldDialog = oldState.parent;
	var newDialog = state.parent;
});
personList.dispose = () => {
}
personList.navigating = (data, url, navigate) => {
	navigate();
}
personList.navigated = (data) => {	
}

// Navigation
Navigation.start('home');
Navigation.StateController.navigate('person');
Navigation.StateController.refresh();
Navigation.StateController.refresh({ page: 2 });
Navigation.StateController.navigate('select', { id: 10 });
if (Navigation.StateController.canNavigateBack(1)){
	Navigation.StateController.navigateBack(1);	
}

// Navigation Link
var link = Navigation.StateController.getNavigationLink('person');
link = Navigation.StateController.getRefreshLink();
link = Navigation.StateController.getRefreshLink({ page: 2 });
link = Navigation.StateController.getNavigationLink('select', { id: 10 });
Navigation.StateController.navigateLink(link);
link = Navigation.StateController.getNavigationBackLink(1);
var crumb = Navigation.StateController.crumbs[0];
link = crumb.navigationLink;

