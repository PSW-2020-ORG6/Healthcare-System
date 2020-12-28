Vue.component("patient", {
	data: function () {
		return {
			patientDTO: null,
			idPatient: "96736fd7-3018-4f3f-a14b-35610a1c8959",
			activeAppointments: null,
			canceledAppointments: null,
			patients: null,
			doctorsList: null,
			appointment: null			
		}
	},
	beforeMount() {
		axios
			.get('/patient/getPatientById', { params: { patientId: "96736fd7-3018-4f3f-a14b-35610a1c8959" } })
			.then(response => {
				this.patientDTO = response.data
			})
			.catch(error => {
				alert("Please add patient with id number : 96736fd7-3018-4f3f-a14b-35610a1c8959")
			})

		axios
			.get('/feedback/approved')
			.then(response => {
				this.approvedFeedbacks = response.data
			})
			.catch(error => {
				alert(error.response.data)
			})
		axios
			.get('/patient/all')
			.then(response => {
				this.patients = response.data
			})
			.catch(error => {
				alert(error.response.data)
			})

		axios
			.get('/appointment/allAppointmentsByPatientIdActive', { params: { patientId: "96736fd7-3018-4f3f-a14b-35610a1c8959" } })
			.then(response => {
				this.activeAppointments = response.data
			})

			.catch(error => {
				alert(error)
			})

		axios
			.get('/appointment/allAppointmentsByPatientIdCanceled', { params: { patientId: "96736fd7-3018-4f3f-a14b-35610a1c8959" } })
			.then(response => {
				this.canceledAppointments = response.data
			})
			.catch(error => {
				alert(error)
			})
	},
	template: `
	<div id="Patient">
	
        <br></br>
<!-- Advertisements -->
    <div id="carouselExampleControls" class="carousel slide" data-ride="carousel">
      <div class="carousel-inner">
        <div class="carousel-item active" style="height:330px;">
            </br>
            <h3> Vitamin D3 1000 IU</h3></br>
            Vitamin D3 1000 IU doprinosi normalnoj funkciji imunog sistema,</br> koštano-mišićnog sistema, smanjenju gubitka koštane mase kod žena u post-menopauzalnom periodu.</br>
            Podrška imunom sistemu, kao i kod stanja kao što su osteopenija, osteoporoza, autoimuna, kardiovaskularna i maligna oboljenja.
        </br></br>
        </div>
        <div class="carousel-item" v-for="it in [0,1]" style="height:330px;">
            </br>
            <h3>Oligovit Complex Galenika</h3></br>
            Oligovit dražeje se primenjuju:</br>
        - Kao dodatak ishrani u stanjima neadekvatne ishrane (u toku dijete, gladovanja)</br>
        - Kao dopuna u vitaminima i mineralima u toku trudnoće i dojenja</br>
        - Kod premorenosti posle teškog fizičkog napora</br>
        - U stanjima oporavka posle: bolesti praćenih visokim temperaturama, hirurških zahvata</br>
        - Kod zaostajanja u rastenju, nedostatka apetita, gubitka u telesnoj masi</br>
        - Kod deficita nastalog zbog gastrointestinalnih i hepatobilijarnih bolesti</br>
        - Kod patoloških stanja (hipertireoidizam, stres itd.) u kojima su povećane potrebe za vitaminima i mineralima.
        </br></br>
        </div>
      </div>
      <a class="carousel-control-prev" href="#carouselExampleControls" role="button" data-slide="prev">
        <span class="carousel-control-prev-icon" aria-hidden="true"></span>
        <span class="sr-only">Previous</span>
      </a>
      <a class="carousel-control-next" href="#carouselExampleControls" role="button" data-slide="next">
        <span class="carousel-control-next-icon" aria-hidden="true"></span>
        <span class="sr-only">Next</span>
      </a>
    </div></br>
        <br></br>
        <br></br>
        <br></br>
        <!--ICONS ROW 1-->
            <div>
              <div class="row">
                <div class="col-sm">
                </div>
                <div class="col-sm">
                  <h3>
			        <button id="MyInformations" type="button" class="btn btn-info btn-lg margin form-control" data-toggle="modal" v-on:click="AccountInfoShow()"></button>
			        </h3><br/> 
                </div>
                <div class="col-sm">
                </div>
                <div class="col-sm">
                  <h3>
			        <button id="UserExperiences" type="button" class="btn btn-info btn-lg margin form-control" v-on:click="FeedbackShow()"></button>
			        </h3><br/> 
                </div>
                <div class="col-sm">
                </div>
                <div class="col-sm">
                  <h3>
			        <button id="Search" type="button" class="btn btn-info btn-lg margin form-control" v-on:click="SearchShow()"></button>
			        </h3><br/> 
                </div>
                <div class="col-sm">
                </div>
                <div class="col-sm">
                  <h3>
			        <button id="AppointmentsShow" type="button" class="btn btn-info btn-lg margin form-control" v-on:click="AppointmentsShow()"></button>
			        </h3><br/> 
                </div>
                <div class="col-sm">
                </div>
                <div class="col-sm">
                  <h3>
			        <button id="SurveyShow" type="button" class="btn btn-info btn-lg margin form-control" v-on:click="SurveyShow()"></button>
			        </h3><br/> 
                </div>
                <div class="col-sm">
                </div>  
                <div class="col-sm">
                </div>
              </div>
<br></br>
<br></br>

	</div>

	`,
	methods: {
		AddNewFeedback: function (feedback) {
			if (!document.getElementById("anonimous").checked)
				this.feedback.patientId = "0003"
			else
				this.feedback.id = "-1"
			if (feedback.text.localeCompare(null) || feedback.text.localeCompare("")) {
				axios
					.post("/feedback/add", feedback)
					.then(response => {
						this.feedback.text = null;
						$('#feedbackModal').modal('hide')
					})
					.catch(error => {
						alert("You need to enter a comment first.");
					})
			}
			else
				alert("You need to enter a comment first.");
		},
		DateSplit: function (date) {
			var dates = (date.split("T")[0]).split("-")
			return dates[2] + "." + dates[1] + "." + dates[0]
		},
		SearchShow: function () {
			this.$router.push('search');
		},
		AppointmentsShow: function () {
			this.$router.push('appointments');
		},
		SurveyShow: function () {
			axios
				.get('/survey/getDoctorsForSurveyList', { params: { patientId: this.idPatient } })
				.then(response => {
					this.doctorsList = response.data
					if (this.doctorsList.value != null || this.doctorsList != "") {
						this.$router.push('survey');
					} else {
						alert("You have already completed the survey for all available doctors")
					}
				})
				.catch(error => {
					alert(error)
				})
		},
		FeedbackShow: function () {
			this.$router.push('feedbackPatient');
		},
		AccountInfoShow: function () {
			this.$router.push('account');
		}
	}
});