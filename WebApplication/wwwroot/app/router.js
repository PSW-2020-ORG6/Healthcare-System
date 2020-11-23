﻿const Home = { template: '<home></home>' }
const Admin = { template: '<admin></admin>' }
const Patient = { template: '<patient></patient>' }
const Registration = { template: '<registration></registration>' }
const Survey = { template: '<survey></survey>' }
const Statistics = { template: '<statistics></statistics>' }


var temp = new Vue({
	el: '#temp',
	data: {
		isHidden: false
	},
	methods: {
		admin : function () {
			router.push("admin")
		},
		patient: function () {
			router.push("patient")
		},
		home: function () {
			router.push("home")
		},
		registration: function () {
			router.push("registration")
		}
		},
		survey: function () {
			router.push("survey")
		},
		statistics: function () {
			router.push("statistics")
		},
	}

});


const router = new VueRouter({
	mode: 'hash',
	routes: [
		{
			path: '/home',
			name: 'home',
			component: Home,
		},
		{
			path: '/patient',
			name: 'patient',
			component: Patient,
		},
		{
			path: '/admin',
			name: 'admin',
			component: Admin,
		},
		{
			path: '/registration',
			name: 'registration',
			component: Registration,
		},
		{
			path: '/survey',
			name: 'survey',
			component: Survey,
		},	
		{
			path: '/statistics',
			name: 'statistics',
			component: Statistics,
		},	
	]
});

var app = new Vue({

		router
	,
	el: '#routerMode'
});

