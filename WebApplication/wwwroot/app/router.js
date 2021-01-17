const Home = { template: '<home></home>' }
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
const FeedbackPatient = { template: '<feedbackPatient></feedbackPatient>' }
const Account = { template: '<account></account>' }
const FeedbackAdmin = { template: '<feedbackAdmin></feedbackAdmin>' }
const Login = { template: '<login></login>' }
const PageHeader = { template: '<pageHeader></pageHeader>' }
const AdminHeader = { template: '<headerAdmin></headerAdmin>' }
const PatientHeader = { template: '<headerPatient></headerPatient>' }
const Landing = { template: '<landing></landing>' }
const Feedback = { template: '<feedback></feedback>' }
const Charts = { template: '<charts></charts>' }




var temp = new Vue({
	el: '#temp',
	data: {
		isHidden: false
	},
	methods: {
		admin: function () {
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
		},
		appointment: function () {
			router.push("appointment")
		},
		feedbackPatient: function () {
			router.push("feedbackPatient")
		},
		account: function () {
			router.push("account")
		},
		feedbackAdmin: function () {
			router.push("feedbackAdmin")
		},
		login: function () {
			router.push("login")
		},
		pageHeader: function () {
			router.push("pageHeader")
		},
		headerAdmin: function () {
			router.push("headerAdmin")
		},
		headerPatient: function () {
			router.push("headerPatient")
		},
		landing: function () {
			router.push("landing")
		},
		charts: function () {
			router.push("charts")
		},
		feedback: function () {
			router.push("feedback")
		}
	}
});

const router = new VueRouter({
	mode: 'hash',
	routes: [
		{
			path: '/home',
			name: 'home',
			components: {
				pageHeader: PageHeader,
				content: Home
			}
		},

		{
			path: '/patient',
			name: 'patient',
			components: {
				pageHeader: PatientHeader,
				content: Patient
			},
			beforeEnter: (to, from, next) => {
				if (localStorage.getItem('isAdmin') == "false" && localStorage.getItem('isLogged') == "true" && localStorage.getItem('isPatient') == "true") {
					next();
				}
				else {
					next(false);
				}
			}
		},
		{
			path: '/admin',
			name: 'admin',
			components: {
				pageHeader: AdminHeader,
				content: Admin
			},
			beforeEnter: (to, from, next) => {
				if (localStorage.getItem('isAdmin') == "true" && localStorage.getItem('isLogged') == "true" && localStorage.getItem('isPatient') == "false") {
					next();
				}
				else {
					next(false);
				}
			}
		},
		{
			path: '/registration',
			name: 'registration',
			components: {
				pageHeader: PageHeader,
				content: Registration
			},
			beforeEnter: (to, from, next) => {
				if (localStorage.getItem('isAdmin') == "false" && localStorage.getItem('isLogged') == "false" && localStorage.getItem('isPatient') == "false") {
					next();
				}
				else {
					next(false);
				}
			}
		},
		{
			path: '/emailConfirmation',
			name: 'emailConfirmation',
			components: {
				pageHeader: PatientHeader,
				content: EmailConfirmation
			},
			beforeEnter: (to, from, next) => {
				if (localStorage.getItem('isLogged') == "false") {
					next();
				}
				else {
					next(false);
				}
			}
		},
		{
			path: '/successfulRegistration',
			name: 'successfulRegistration',
			components: {
				pageHeader: PatientHeader,
				content: SuccessfulRegistration
			},
			beforeEnter: (to, from, next) => {
				if (localStorage.getItem('isAdmin') == "false" && localStorage.getItem('isLogged') == "false" && localStorage.getItem('isPatient') == "false") {
					next();
				}
				else {
					next(false);
				}
			}
		},
		{
			path: '/survey',
			name: 'survey',
			components: {
				pageHeader: PatientHeader,
				content: Survey
			},
			beforeEnter: (to, from, next) => {
				if (localStorage.getItem('isAdmin') == "false" && localStorage.getItem('isLogged') == "true" && localStorage.getItem('isPatient') == "true") {
					next();
				}
				else {
					next(false);
				}
			}
		},
		{
			path: '/statistics',
			name: 'statistics',
			components: {
				pageHeader: AdminHeader,
				content: Statistics
			},
			beforeEnter: (to, from, next) => {
				if (localStorage.getItem('isAdmin') == "true" && localStorage.getItem('isLogged') == "true" && localStorage.getItem('isPatient') == "false") {
					next();
				}
				else {
					next(false);
				}
			}
		},
		{
			path: '/search',
			name: 'search',
			components: {
				pageHeader: PatientHeader,
				content: Search
			},
			beforeEnter: (to, from, next) => {
				if (localStorage.getItem('isLogged') == "true") {
					next();
				}
				else {
					next(false);
				}
			}
		},
		{
			path: '/appointments',
			name: 'appointments',
			components: {
				pageHeader: PatientHeader,
				content: Appointments
			},
			beforeEnter: (to, from, next) => {
				if (localStorage.getItem('isAdmin') == "false" && localStorage.getItem('isLogged') == "true" && localStorage.getItem('isPatient') == "true") {
					next();
				}
				else {
					next(false);
				}
			}
		},
		{
			path: '/feedbackPatient',
			name: 'feedbackPatient',
			components: {
				pageHeader: PatientHeader,
				content: FeedbackPatient
			},
			beforeEnter: (to, from, next) => {
				if (localStorage.getItem('isAdmin') == "false" && localStorage.getItem('isLogged') == "true" && localStorage.getItem('isPatient') == "true") {
					next();
				}
				else {
					next(false);
				}
			}
		},
		{
			path: '/account',
			name: 'account',
			components: {
				pageHeader: PatientHeader,
				content: Account
			},
			beforeEnter: (to, from, next) => {
				if (localStorage.getItem('isAdmin') == "false" && localStorage.getItem('isLogged') == "true" && localStorage.getItem('isPatient') == "true") {
					next();
				}
				else {
					next(false);
				}
			}
		},
		{
			path: '/feedbackAdmin',
			name: 'feedbackAdmin',
			components: {
				pageHeader: AdminHeader,
				content: FeedbackAdmin
			},
			beforeEnter: (to, from, next) => {
				if (localStorage.getItem('isAdmin') == "true" && localStorage.getItem('isLogged') == "true" && localStorage.getItem('isPatient') == "false") {
					next();
				}
				else {
					next(false);
				}
			}
		},
		{
			path: '/login',
			name: 'login',
			components: {
				pageHeader: PageHeader,
				content: Login
			},
			beforeEnter: (to, from, next) => {
				if (localStorage.getItem('isAdmin') == "false" && localStorage.getItem('isLogged') == "false" && localStorage.getItem('isPatient') == "false") {
					next();
				}
				else {
					next(false);
				}
			}
		},
		{
			path: '/landing',
			name: 'landing',
			components: {
				pageHeader: PageHeader,
				content: Landing
			},
			beforeEnter: (to, from, next) => {
				if (localStorage.getItem('isAdmin') == "false" && localStorage.getItem('isLogged') == "false" && localStorage.getItem('isPatient') == "false") {
					next();
				}
				else {
					next(false);
				}
			}
		},
		{
			path: '/feedback',
			name: 'feedback',
			components: {
				pageHeader: PageHeader,
				content: Feedback
			},
			beforeEnter: (to, from, next) => {
				if (localStorage.getItem('isAdmin') == "false" && localStorage.getItem('isLogged') == "false" && localStorage.getItem('isPatient') == "false") {
					next();
				}
				else {
					next(false);
				}
			}
		},
		{
			path: '/',
			components: {
				pageHeader: PageHeader,
				content: Landing
			}
		},
		{
			path: '/charts',
			name: 'charts',
			components: {
				pageHeader: AdminHeader,
				content: Charts
			}
		},
		{
			path: '*',
			components: {
				pageHeader: PageHeader,
				content: Landing
			},
			beforeEnter: (to, from, next) => {
				next(false);
			}
		},
	]
});
var app = new Vue({
	router
	,
	el: '#routerMode'
});
