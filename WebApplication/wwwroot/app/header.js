Vue.component("pageHeader", {
    data: function () {
        return {
            isLogged: false,
            isAdmin: false,
            isPatient:false
        }
    },
    mounted() {
            this.isAdmin = localStorage.getItem('isAdmin')
            this.isPatient = localStorage.getItem('isPatient')
            this.isLogged = localStorage.getItem('isLogged')
    }
    ,
    template: `
	<div>
		<div id="temp">

            <nav class="navbar navbar-expand-lg"> 
              <div class="collapse navbar-collapse" id="navbarText">
                <ul class="navbar-nav mr-auto">
                    <li id="clinicLogo">
                        <a id="">Health Clinic <img src="pictures/logInverted.png"></a>
                     </li>
                </ul>
                <span class="navbar-text">
                   <ul class="navbar-nav mr-auto">
                      <li class="nav-item">
                    <a class="nav-link navItem " href="#" v-on:click="LoginShow()">Login</a>
                      </li>
                      <li class="nav-item">
                    <a class="nav-link navItem " href="#" v-on:click="RegistrationShow()">Registration</a>
                      </li>
                </ul>
                </span>
              </div>
            </nav>

	</div>

	`,
    methods: {
        AccountShow: function () {
            this.$router.push('account');
        },
        FeedbackPatientShow: function () {
            this.$router.push('feedbackPatient');
        },
        FeedbacksAdminShow: function () {
            this.$router.push('feedbackAdmin');
        },
         AppointmentsShow: function () {
            this.$router.push('survey');
        },
        SearchShow: function () {
            this.$router.push('search');
        },
        StatisticsShow: function () {
            this.$router.push('statistics');
        },
        AdminShow: function () {
            this.$router.push('admin');
        },
        PatientShow: function () {
            this.$router.push('patient');
        },
        RegistrationShow: function () {
            this.$router.push('registration');
        },
        FeedbackShow: function () {
            this.$router.push('feedback');
        },
        LoginShow: function () {
            this.$router.push('Login');
        }
    }
});
