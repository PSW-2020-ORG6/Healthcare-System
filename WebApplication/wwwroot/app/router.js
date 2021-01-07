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
			}
		},
		{
			path: '/admin',
			name: 'admin',
			components: {
				pageHeader: AdminHeader,
				content: Admin
			}
		},
		{
			path: '/registration',
			name: 'registration',
			components: {
				pageHeader: PageHeader,
				content: Registration
			}
		},
		{
			path: '/emailConfirmation',
			name: 'emailConfirmation',
			components: {
				pageHeader: PatientHeader,
				content: EmailConfirmation
			}
		},
		{
			path: '/successfulRegistration',
			name: 'successfulRegistration',
			components: {
				pageHeader: PatientHeader,
				content: SuccessfulRegistration
			}
		},
		{
			path: '/survey',
			name: 'survey',
			components: {
				pageHeader: PatientHeader,
				content: Survey
			}
		},	
		{
			path: '/statistics',
			name: 'statistics',
			components: {
				pageHeader: AdminHeader,
				content: Statistics
			}
		},	
		{
			path: '/search',
			name: 'search',
			components: {
				pageHeader: PatientHeader,
				content: Search
			}
		},
		{
			path: '/appointments',
			name: 'appointments',
			components: {
				pageHeader: PatientHeader,
				content: Appointments
			}
		},
		{
			path: '/appointment',
			name: 'appointment',
			components: {
				pageHeader: PatientHeader,
				content: Appointment
			}
		},
		{
			path: '/feedbackPatient',
			name: 'feedbackPatient',
			components: {
				pageHeader: PatientHeader,
				content: FeedbackPatient
			}
		},
		{
			path: '/account',
			name: 'account',
			components: {
				pageHeader: PatientHeader,
				content: Account
			}
		},
		{
			path: '/feedbackAdmin',
			name: 'feedbackAdmin',
			components: {
				pageHeader: AdminHeader,
				content: FeedbackAdmin
			}
		},
		{
			path: '/',
			components: {
				pageHeader: PageHeader,
				content: Login
			}
		},
	]
});
var app = new Vue({
		router
	,
	el: '#routerMode'
});


