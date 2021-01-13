Vue.component("landing", {
	template: `
	<div id="Landing"></br>
			<a class="text2" style="color:white;font-style:italic">
            Welcome to HealthClinic
            <img src="pictures/logInverted.png" id="clinicLogoPic">
			<br></br>
			Wherever the art of Medicine is loved, there is also a love of Humanity.</br> ~Hippocrates
			</a>
	<br></br>
	<br></br>
		</div>
	</div>

	`
});

Vue.component("feedback", {
	data: function () {
		return {
			approvedFeedbacks: null,
			patients: null,
		}
	},
	beforeMount() {
			axios
				.get('/feedback/approved')
				.then(response => {
					this.approvedFeedbacks = response.data
				})
				.catch(error => {
				})
		axios
			.get('/patient/all', {
				params: { token: localStorage.getItem('token')}
			})
			.then(response => {
				this.patients = response.data
			})
			.catch(error => {
			})
	},
	template: `
	<div id="FeedbackPatient">

<!--User feedbacks -->
	<template v-for="a in approvedFeedbacks">
		<template v-for="p in patients">
			<div class="container" v-if="parseInt(a.patientId) != -1 && parseInt(p.id) == parseInt(a.patientId)">
			  <div class="card">
					<div class="card-header">{{p.name}} {{p.surname}} - {{DateSplit(a.date)}}</div>
					<div class="card-body" style="font-size:28px">{{a.text}}</div>
				</div></br>
			  </div>
		</template>
			<div class="container" v-if="parseInt(a.patientId) == -1">
			  <div class="card">
					<div class="card-header">Annonimous - {{DateSplit(a.date)}}</div>
					<div class="card-body" style="font-size:28px">{{a.text}}</div>
				</div></br>
			  </div>
	</template></br>
<!--END User comments -->

	</div>

	`,
	methods: {
		DateSplit: function (date) {
			var dates = (date.split("T")[0]).split("-")
			return dates[2] + "." + dates[1] + "." + dates[0]
		}
	}
});
