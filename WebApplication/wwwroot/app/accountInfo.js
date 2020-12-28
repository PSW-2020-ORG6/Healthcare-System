Vue.component("account", {
	data: function () {
		return {
			patientDTO: null,
			idPatient: "96736fd7-3018-4f3f-a14b-35610a1c8959"
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
	
	},
	template: `
	<div id="Account"></br>

<!-- Registration Info -->
							<td><img  :src = "patientDTO.image" class = "form-control inputImage" style = "display:flex" width="100" heigh="50"/></td></br>
							<div class="input-group mb-3">
							  <div class="input-group-prepend">
								<span class="input-group-text width" id="basic-addon3">Name</span>
							  </div>
							  <input type="text"  v-model="patientDTO.name" class="form-control" id="basic-url" aria-describedby="basic-addon3" disabled>
						
								<td>&nbsp&nbsp&nbsp</td>


							  <div class="input-group-prepend">
								<span class="input-group-text width" id="basic-addon3">Surname</span>
							  </div>
							  <input type="text"  v-model="patientDTO.surname" class="form-control" id="basic-url" aria-describedby="basic-addon3" disabled>
							</div>

							<div class="input-group mb-3">
							  <div class="input-group-prepend">
								<span class="input-group-text width" id="basic-addon3">UCIN</span>
							  </div>
							  <input type="text"  v-model="patientDTO.id" class="form-control" id="basic-url" aria-describedby="basic-addon3" disabled>
						
								<td>&nbsp&nbsp&nbsp</td>


							  <div class="input-group-prepend">
								<span class="input-group-text width" id="basic-addon3">Date of Birth</span>
							  </div>
							  <input type="text"  v-model="patientDTO.dateOfBirth" class="form-control" id="basic-url" aria-describedby="basic-addon3" disabled>
						</div>

							<div class="input-group mb-3">
							  <div class="input-group-prepend">
								<span class="input-group-text width" id="basic-addon3">Place of birth</span>
							  </div>
							  <input type="text"  v-model="patientDTO.placeOfBirth" class="form-control" id="basic-url" aria-describedby="basic-addon3" disabled>

								<td>&nbsp&nbsp&nbsp</td>


							  <div class="input-group-prepend">
								<span class="input-group-text width" id="basic-addon3">Municipality of birth</span>
							  </div>
							  <input type="text"  v-model="patientDTO.municipalityOfBirth" class="form-control" id="basic-url" aria-describedby="basic-addon3" disabled>
						</div>

							<div class="input-group mb-3">
							  <div class="input-group-prepend">
								<span class="input-group-text width" id="basic-addon3">State of birth</span>
							  </div>
							  <input type="text"  v-model="patientDTO.stateOfBirth" class="form-control" id="basic-url" aria-describedby="basic-addon3" disabled>
						
								<td>&nbsp&nbsp&nbsp</td>


							  <div class="input-group-prepend">
								<span class="input-group-text width" id="basic-addon3">Nationality</span>
							  </div>
							  <input type="text"  v-model="patientDTO.nationality" class="form-control" id="basic-url" aria-describedby="basic-addon3" disabled>
						</div>

							<div class="input-group mb-3">
							  <div class="input-group-prepend">
								<span class="input-group-text width" id="basic-addon3">Citizenship</span>
							  </div>
							  <input type="text"  v-model="patientDTO.citizenship" class="form-control" id="basic-url" aria-describedby="basic-addon3" disabled>
						
								<td>&nbsp&nbsp&nbsp</td>


							  <div class="input-group-prepend ">
								<span class="input-group-text width" id="basic-addon3">Address</span>
							  </div>
							  <input type="text"  v-model="patientDTO.address.street" class="form-control" id="basic-url" aria-describedby="basic-addon3" disabled>
						</div>

							<div class="input-group mb-3">
							  <div class="input-group-prepend">
								<span class="input-group-text width" id="basic-addon3">Place of residence</span>
							  </div>
							  <input type="text"  v-model="patientDTO.placeOfResidence" class="form-control" id="basic-url" aria-describedby="basic-addon3" disabled>
						
								<td>&nbsp&nbsp&nbsp</td>


							  <div class="input-group-prepend">
								<span class="input-group-text width" id="basic-addon3">Municipality of residence</span>
							  </div>
							  <input type="text"  v-model="patientDTO.municipalityOfResidence" class="form-control" id="basic-url" aria-describedby="basic-addon3" disabled>
						</div>

							<div class="input-group mb-3">
							  <div class="input-group-prepend">
								<span class="input-group-text width" id="basic-addon3">State of residence</span>
							  </div>
							  <input type="text"  v-model="patientDTO.stateOfResidence" class="form-control" id="basic-url" aria-describedby="basic-addon3" disabled>
						
								<td>&nbsp&nbsp&nbsp</td>


							  <div class="input-group-prepend">
								<span class="input-group-text width" id="basic-addon3">Profesion</span>
							  </div>
							  <input type="text"  v-model="patientDTO.profession" class="form-control" id="basic-url" aria-describedby="basic-addon3" disabled>
						</div>

							<div class="input-group mb-3">
							  <div class="input-group-prepend">
								<span class="input-group-text width" id="basic-addon3">Employment status</span>
							  </div>
							  <input type="text"  v-model="patientDTO.employmentStatus" class="form-control" id="basic-url" aria-describedby="basic-addon3" disabled>
						
								<td>&nbsp&nbsp&nbsp</td>


							  <div class="input-group-prepend">
								<span class="input-group-text width" id="basic-addon3">Marital status</span>
							  </div>
							  <input type="text"  v-model="patientDTO.maritalStatus" class="form-control" id="basic-url" aria-describedby="basic-addon3" disabled>
						</div>

							<div class="input-group mb-3">
							  <div class="input-group-prepend">
								<span class="input-group-text width" id="basic-addon3">Contact number</span>
							  </div>
							  <input type="text"  v-model="patientDTO.contact" class="form-control" id="basic-url" aria-describedby="basic-addon3" disabled>
							
								<td>&nbsp&nbsp&nbsp</td>

							  <div class="input-group-prepend">
								<span class="input-group-text width" id="basic-addon3">Email</span>
							  </div>
							  <input type="text"  v-model="patientDTO.email" class="form-control" id="basic-url" aria-describedby="basic-addon3" disabled>
						</div>

							<div class="input-group mb-3">
							  <div class="input-group-prepend">
								<span class="input-group-text width" id="basic-addon3">Gender</span>
							  </div>
							  <input type="text"  v-model="patientDTO.gender" class="form-control" id="basic-url" aria-describedby="basic-addon3" disabled>
						
								<td>&nbsp&nbsp&nbsp</td>

							  <div class="input-group-prepend">
								<span class="input-group-text width" id="basic-addon3">Health insurance number</span>
							  </div>
							  <input type="text"  v-model="patientDTO.healthInsuranceNumber" class="form-control" id="basic-url" aria-describedby="basic-addon3" disabled>
						</div>

							<div class="input-group mb-3">
							  <div class="input-group-prepend">
								<span class="input-group-text width" id="basic-addon3">Family diseases</span>
							  </div>
							  <input type="text"  v-model="patientDTO.familyDiseases" class="form-control" id="basic-url" aria-describedby="basic-addon3" disabled>
						
								<td>&nbsp&nbsp&nbsp</td>

							  <div class="input-group-prepend">
								<span class="input-group-text width" id="basic-addon3">Personal diseases</span>
							  </div>
							  <input type="text"  v-model="patientDTO.personalDiseases" class="form-control" id="basic-url" aria-describedby="basic-addon3" disabled>
						</div>

							<div class="input-group mb-3" style="width:50%">
							  <div class="input-group-prepend">
								<span class="input-group-text width" id="basic-addon3">Chosen doctor</span>
							  </div>
							  <input type="text"  v-model="patientDTO.chosenDoctor" class="form-control" id="basic-url" aria-describedby="basic-addon3" disabled>&nbsp&nbsp
						</div></br></br>
	
	<!--END registration info modal-->

	</div>

	`
});
