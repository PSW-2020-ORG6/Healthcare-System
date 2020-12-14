﻿const Home = { template: '<home></home>' }
const Admin = { template: '<admin></admin>' }
const Patient = { template: '<patient></patient>' }
const Registration = { template: '<registration></registration>' }
const EmailConfirmation = { template: '<emailConfirmation></emailConfirmation>' }
const SuccessfulRegistration = { template: '<successfulRegistration></successfulRegistration>' }
const Survey = { template: '<survey></survey>' }
const Statistics = { template: '<statistics></statistics>' }
const Search = { template: '<search></search>' }
const Appointments = { template: '<appointments></appointments>' }
const Appointment = { template: '<appointment></appointment>' }
const Appointments = { template: '<appointments></appointments>' }



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
		},
		emailConfirmation: function () {
			router.push("emailConfirmation")
		},
		successfulTegistration: function () {
			router.push("successfulRegistration")
		},
		survey: function () {
			router.push("survey")
		},
		statistics: function () {
			router.push("statistics")
		},
		search: function () {
			router.push("search")
		},
		appointments: function () {
			router.push("appointments")
		}
		},
		appointment: function () {
			router.push("appointment")
		},
		appointments: function () {
			router.push("appointments")
		}
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
			path: '/emailConfirmation',
			name: 'emailConfirmation',
			component: EmailConfirmation,
		},
		{
			path: '/successfulRegistration',
			name: 'successfulRegistration',
			component: SuccessfulRegistration,
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
		{
			path: '/search',
			name: 'search',
			component: Search,
		},
		{
			path: '/appointments',
			name: 'appointments',
			component: Appointments,
		},
		{
			path: '/appointment',
			name: 'appointment',
			component: Appointment,
		},
		{
			path: '/appointments',
			name: 'appointments',
			component: Appointments,
		}
	]
});
var app = new Vue({
		router
	,
	el: '#routerMode'
});

