const Home = { template: '<home></home>' }
const Admin = { template: '<admin></admin>' }
const Patient = { template: '<patient></patient>' }
const Survey = { template: '<survey></survey>' }


var temp = new Vue({
	el: '#temp',
	data: {
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
		survey: function () {
			router.push("survey")
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
			path: '/survey',
			name: 'survey',
			component: Survey,
		},	
	]
});

var app = new Vue({

		router
	,
	el: '#routerMode'
});

