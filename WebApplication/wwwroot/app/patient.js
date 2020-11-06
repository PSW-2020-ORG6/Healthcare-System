Vue.component("patient", {
	data: function () {
		return {
			feedback: {
				text: "",
				approved: false,
				date: new Date().now,
				user: "TODO",
				patientId: "TODO7",
				serialNumber: "TODO7"
			}
		}
	},
	template: `
    data: function () {
        return {
        }
    },
    template: `
        <div>



	     <button type="button" class="btn btn-info btn-lg" data-toggle="modal" data-target="#feedbackModal">Open Modal</button>

		<div class="modal fade" tabindex="-1" role="dialog" id="feedbackModal">
			<div class="modal-dialog" role="document">
				<div class="modal-content">
					<div class="modal-header">
						<h5 class="modal-title">Leave Feedback</h5>
						<button type="button" class="close" data-dismiss="modal" aria-label="Close">
							<span aria-hidden="true">&times;</span>
						</button>
					</div>
					<div class="modal-body">

						<label>Enter your comment here:</label>
						<input type="text" class="form-control" v-model="feedback.text">

						<label id="ratingLabel">Rate us</label>
						<div class="rating">
							<input type="radio" name="rating" value="5" id="5"><label for="5">☆</label> <input type="radio" name="rating" value="4" id="4"><label for="4">☆</label> <input type="radio" name="rating" value="3" id="3"><label for="3">☆</label> <input type="radio" name="rating" value="2" id="2"><label for="2">☆</label> <input type="radio" name="rating" value="1" id="1"><label for="1">☆</label>
						</div>
					</div>
					<div class="modal-footer">
						<button type="button" class="btn btn-info btn-lg " v-on:click="addNewFeedback(feedback)">Save changes</button>
						<button type="button" class="btn btn-info btn-lg " data-dismiss="modal">Close</button>
					</div>
				</div>
			</div>
		</div>  		
	








    </div>
	`,
	methods: {
		addNewFeedback: function (feedback) {



			axios
				.post("http://localhost:49900/feedback/add", feedback)

		}
	}

});