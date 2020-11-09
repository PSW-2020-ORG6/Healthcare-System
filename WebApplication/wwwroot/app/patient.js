Vue.component("patient", {
	data: function () {
		return {
			approvedFeedbacks: null,
			noapprovedFeedbacks: null,
			patients: null,
			feedback: {
				text: "",
				approved: false,
				date: new Date().now,
				patientId: "-1"
			}
		}
	},
	beforeMount() {
		axios
			.get('http://localhost:49900/feedback/approved')
			.then(response => {
				this.approvedFeedbacks = response.data
			})
			.catch(error => {
				alert(error.response.data)
			})

		axios
			.get('http://localhost:49900/patient/all')
			.then(response => {
				this.patients = response.data
			})
			.catch(error => {
				alert(error.response.data)
			})
	},
	template: `
	<div>
		<div>
			<div class="modal fade" tabindex="-1" role="dialog" id="feedbackModal">
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
		<div class="container"><br/>
			<h3 class="text">Comments
				<button type="button" class="btn btn-info btn-lg margin" data-toggle="modal" data-target="#feedbackModal">Add comment</button>
			</h3><br/>    
			<div>
				<div class="tab-content">
    				<div id="profil" class="container tab-pane active"><br>
    					<div class="container">
							<div class="row">
								<table class="table table-bordered">
									<thead>
										<tr>
											<th>Comment</th>
											<th>Date</th>
											<th colspan="2">Patient</th>
										</tr>
									</thead>
									<tbody>
										<tr v-for="f in approvedFeedbacks">
											<td>{{f.text}}</td>
											<td>{{DateSplit(f.date)}}</td>
											<td v-for="p in patients" v-if="parseInt(p.id) == parseInt(f.patientId)">{{p.name}} {{p.surname}}</td>
											<td v-if="parseInt(f.patientId) == -1">Anonimous</td>
										</tr>
									</tbody>
								</table>
							</div>
						</div>			     
					</div>
				</div>
			</div>
		</div>
	</div>
	`,
	methods: {
		AddNewFeedback: function (feedback) {
			if (!document.getElementById("anonimous").checked)
				this.feedback.patientId="0003"
			if (feedback.text != null || feedback.text!="") {
				axios
					.post("http://localhost:49900/feedback/add", feedback)
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
		}
	}
});