Vue.component("headerPatient", {
    data: function () {
        return {
           
        }
    },
    
    template: `
	<div>
		<div id="temp">
        <nav class="navbar navbar-expand-lg navbar-custom " id="navigationBar">
            <div class="collapse navbar-collapse " id="navbarSupportedContent">
                <ul class="navbar-nav mr-auto">
                    <li class="nav-item dropdown">
                        <button type="button" class="btn btn-info btn-lg nav-link navbar-brand dropdown-toggle" href="#" id="navbarDropdown" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false" >Patient menu</button>
                        <div class="dropdown-menu" aria-labelledby="navbarDropdown">
                            <a class="dropdown-item" v-on:click="PatientShow()">Home</a>
                            <div class="dropdown-divider"></div>
                            <a class="dropdown-item" v-on:click="AccountShow()">My account</a>
                            <a class="dropdown-item" v-on:click="FeedbackPatientShow()">Feedbacks</a>
                            <a class="dropdown-item" v-on:click="AppointmentsShow()">Appointments</a>
                            <a class="dropdown-item" v-on:click="AppointmentsShow()">Survay</a>
                            <a class="dropdown-item" v-on:click="SearchShow()">Search</a>
                            <div class="dropdown-divider"></div>
                            <a class="dropdown-item" href="#">Log out</a>
                        </div>     
                    </li>
                    <li class="nav-item">
                        <h1 class="navbar-brand" id="clinicLogoTxt">Health Clinic</h1>
                        <img src="pictures/logInverted.png" id="clinicLogoPic">
                    </li>
                </ul>
            </div>
        </nav>
    </div>
	</div>

	`,
    methods: {
        AccountShow: function () {
            this.$router.push('accoutnInfo');
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
        }
    }


});
