Vue.component("feedbackPatient", {
	data: function () {
		return {
			idPatient: "96736fd7-3018-4f3f-a14b-35610a1c8959",
			approvedFeedbacks: null,
			patients: null,
			feedback: {
				text: "",
				approved: false,
				date: new Date().now,
				patientId: "96736fd7-3018-4f3f-a14b-35610a1c8959"
			},
		}
	},
	beforeMount() {
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
	},
	template: `
	<div id="FeedbackPatient">
		<div class="container">
            <br/><h3 class="text">Feedbacks</h3><br/><br/>
			        <button type="button" class="btn btn-info btn-lg form-control" style="width:200px;margin-right:800px" data-toggle="modal" data-target="#CommentModal">Leave feedback</butto>
		</div>

	<!-- Leave Comment -->
		<div>
			<div class="modal fade" tabindex="-1" role="dialog" id="CommentModal">
				<div class="modal-dialog" role="document">
					<div class="modal-content">
						<div class="modal-header" id="feedbackModalHeader">
							<h5 class="modal-title">Leave a comment</h5>
							<button type="button" class="close" data-dismiss="modal" aria-label="Close">
								<span aria-hidden="true">&times;</span>
							</button>
						</div>
						<div class="modal-body" id="feedbackModalBody">
							<label>Enter your comment here:</label>
							<textarea class="form-control" v-model="feedback.text" rows="4" cols="50"></textarea>
							<br/><br/>
							<input type="checkbox" id="anonimous">	
							<label> Anonimous</label><br>
						</div>
						<div class="modal-footer" id="feedbackModalFooter">
							<button type="button" class="btn btn-info btn-lg " v-on:click="AddNewFeedback(feedback)">Send</button>
							<button type="button" class="btn btn-info btn-lg " data-dismiss="modal">Cancel</button>
						</div>
					</div>
				</div>
			</div>  
		</div>
<!--END Leave Comment -->

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

		}
	}
});
