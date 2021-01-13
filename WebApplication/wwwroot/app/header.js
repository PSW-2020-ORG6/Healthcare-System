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
        <nav class="navbar navbar-expand-lg navbar-custom " id="navigationBar">
            <div class="collapse navbar-collapse " id="navbarSupportedContent">
                <ul class="navbar-nav mr-auto">
                    <li  class="nav-item">
                        <div>
                        <button type="button" class="btn btn-info btn-lg navbar-brand" v-on:click="FeedbackShow()">What our patients think of us?</button>
                        </div>
                    </li>
                    <li class="nav-item dropdown">
                        <div v-if="isLogged==true &&isAdmin==false && isPatient==true">
                        <button type="button" class="btn btn-info btn-lg nav-link navbar-brand dropdown-toggle" href="#" id="navbarDropdown" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false" >Patient menu</button>
                        <div class="dropdown-menu" aria-labelledby="navbarDropdown">
                            <a class="dropdown-item" v-on:click="PatientShow()">Home</a>
                            <div class="dropdown-divider"></div>
                            <a class="dropdown-item" v-on:click="AccountShow()">My account</a>
                            <a class="dropdown-item" v-on:click="FeedbackPatientShow()">Feedbacks</a>
                            <a class="dropdown-item" v-on:click="AppointmentsShow()">Appointments</a>
                            <a class="dropdown-item" v-on:click="SearchShow()">Search</a>
                            <div class="dropdown-divider"></div>
                            <a class="dropdown-item" href="#">Log out</a>
                        </div>
                        </div>     
                        <div v-else-if="isLogged==true && isAdmin==true && isPatient==false">
                        <button type="button" class="btn btn-info btn-lg nav-link navbar-brand dropdown-toggle" href="#" id="navbarDropdown" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false" >Admin menu</button>
                        <div class="dropdown-menu" aria-labelledby="navbarDropdown">
                            <a class="dropdown-item" v-on:click="AdminShow()">Home</a>
                            <div class="dropdown-divider"></div>
                            <a class="dropdown-item" v-on:click="StatisticsShow()">Statistics</a>
                            <a class="dropdown-item" v-on:click="FeedbacksAdminShow()">Feedbacks</a>
                            <a class="dropdown-item" href="#">Malicious users</a>
                            <a class="dropdown-item" v-on:click="SearchShow()">Search</a>
                            <div class="dropdown-divider"></div>
                            <a class="dropdown-item" href="#">Log out</a>
                        </div>
                        </div>
                    </li>
                    <li class="nav-item">
                        <h1 class="navbar-brand" id="clinicLogoTxt">Health Clinic</h1>
                        <img src="pictures/logInverted.png" id="clinicLogoPic">
                    </li>
                    <li class="nav-item" id="content">
                        <button type="button" class="btn1 btn btn-info btn-lg navbar-brand" id="registration" v-on:click="RegistrationShow()">Registration</button>
                    </li>
                    <li class="nav-item" id="content">
                        <button type="button" class="btn0 btn btn-info btn-lg navbar-brand" id="login" v-on:click="LoginShow()">Login</button>
                    </li>
                </ul>
            </div>
        </nav>
    </div>
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
