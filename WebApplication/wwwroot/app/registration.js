﻿Vue.component("registration", {
	data: function () {
		return {
			patientDTO: {
				name: null,
				surname: null,
				id: null,
				dateOfBirth: null,
				contact: null,
				email: null,
				address: null,
				password: null,
				parentName: null,
				placeOfBirth: null,
				municipalityOfBirth: null,
				stateOfBirth: null,
				citizenship: null,
				nationality: null,
				profession: null,
				placeOfResidence: null,
				municipalityOfResidence: null,
				stateOfResidence: null,
				employmentStatus: null,
				maritalStatus: null,
				gender: null,
				healthInsuranceNumber: null,
				familyDiseases: null,
				personalDiseases: null,
				image: null,
				guest: false,
				emailConfirmed: false,
				sucessFlag: false,
			},
		}
	},
	template: `
    <div class="container">
        <br/><h2 class="text1">Registration</h2>
		<hr class="line">
		
		<table class="t">
			<colgroup>
                 <col style="width: 60%;">
                 <col style="width: 40%;">
            </colgroup>
			<tr>
				<td><label>Name</label><a class="star">*</a></td>
				<td><input type="text" class = "form-control input" v-model="patientDTO.name"/></td><br/>
			<tr>
			<tr><td>&nbsp;</td>
				 <td align="left" style="color: red;font-size:12px">{{nameValidation}}</td>
			</tr>
			<tr>
				<td><label>Surname</label><a class="star">*</a></td>
				<td><input type="text" class = "form-control input" v-model="patientDTO.surname"/></td><br/>
			</tr>
			<tr><td>&nbsp;</td>
				 <td align="left" style="color: red;font-size:12px">{{surnameValidation}}</td>
			</tr>
			<tr>
				<td><label>Parent name</label><a class="star">*</a></td>
				<td><input type="text" class = "form-control input" v-model="patientDTO.parentName"/></td><br/>
			</tr>
			<tr><td>&nbsp;</td>
				 <td align="left" style="color: red;font-size:12px">{{parentNameValidation}}</td>
			</tr>
			<tr>
				<td><label>Unique citizens identity number</label><a class="star">*</a></td>
				<td><input type="number" class = "form-control input" v-model="patientDTO.id"/></td><br/>
			</tr>
			<tr>
				<td>&nbsp;</td>
				<td></td>
			</tr>
			<tr>
				<td><label>Date of birth</label><a class="star">*</a></td>
				<td><input type="date" class = "form-control input" v-model="patientDTO.dateOfBirth"/></td><br/>
			</tr>
			<tr>
				<td>&nbsp;</td>
				<td></td>
			</tr>
			<tr>
				<td><label>Place of birth</label><a class="star">*</a></td>
				<td><input type="text" class = "form-control input" v-model="patientDTO.placeOfBirth"/></td><br/>
			</tr>
			<tr>
				<td>&nbsp;</td>
				<td></td>
			</tr>
			<tr>
				<td><label>Municipality of birth</label><a class="star">*</a></td>
				<td><input type="text" class = "form-control input" v-model="patientDTO.municipalityOfBirth"/></td><br/>
			</tr>
			<tr>
				<td>&nbsp;</td>
				<td></td>
			</tr>
			<tr>
				<td><label>State of birth</label><a class="star">*</a></td>
				<td><input type="text" class = "form-control input" v-model="patientDTO.stateOfBirth"/></td><br/>
			</tr>
			<tr>
				<td>&nbsp;</td>
				<td></td>
			</tr>
			<tr>
				<td><label>Nationality</label><a class="star">*</a></td>
				<td><input type="text" class = "form-control input" v-model="patientDTO.nationality"/></td><br/>
			</tr>
			<tr>
				<td>&nbsp;</td>
				<td></td>
			</tr>
			<tr>
				<td><label>Citizenship</label><a class="star">*</a></td>
				<td><input type="text" class = "form-control input" v-model="patientDTO.citizenship"/></td><br/>
			</tr>
			<tr>
				<td>&nbsp;</td>
				<td></td>
			</tr>
			<tr>
				<td><label>Address</label><a class="star">*</a></td>
				<td><input type="text" class = "form-control input" v-model="patientDTO.address"/></td><br/>
			</tr>
			<tr>
				<td>&nbsp;</td>
				<td></td>
			</tr>
			<tr>
				<td><label>Place of residence</label><a class="star">*</a></td>
				<td><input type="text" class = "form-control input" v-model="patientDTO.placeOfResidence"/></td><br/>
			</tr>
			<tr>
				<td>&nbsp;</td>
				<td></td>
			</tr>
			<tr>
				<td><label>Municipality of residence</label><a class="star">*</a></td>
				<td><input type="text" class = "form-control input" v-model="patientDTO.municipalityOfResidence"/></td><br/>
			</tr>
			<tr>
				<td>&nbsp;</td>
				<td></td>
			</tr>
			<tr>
				<td><label>State of residence</label><a class="star">*</a></td>
				<td><input type="text" class = "form-control input" v-model="patientDTO.stateOfResidence"/></td><br/>
			</tr>
			<tr><td><hr></td>
				<td><hr></td></tr>
		
			</table>
			<table class="t">
			<tr>
				<td><label>Profesion</label><a class="star">*</a></td>
				<td><input type="text" class = "form-control input" v-model="patientDTO.profession"/></td><br/>
			</tr>
			<tr>
				<td>&nbsp;</td>
				<td></td>
			</tr>
			<tr>
				<td><label>Employment status</label><a class="star">*</a></td>
				<td><select  class="combo form-control input" v-model="patientDTO.employmentStatus">
					<option>Employed</option>
					<option>Unemployed</option>
				</select></td><br/>
			</tr>
			<tr>
				<td>&nbsp;</td>
				<td></td>
			</tr>
			<tr>
				<td><label>Marital status</label><a class="star">*</a></td>
				<td><select class="combo form-control input" v-model="patientDTO.maritalStatus">
					<option>Married</option>
					<option>Mot married</option>
				</select></td><br/>
			</tr>
			<tr>
				<td>&nbsp;</td>
				<td></td>
			</tr>
			<tr>
				<td><label>Contact number</label><a class="star">*</a></td>
				<td><input type="number" class = "form-control input" v-model="patientDTO.contact"/></td><br/>
			</tr>
			<tr>
				<td>&nbsp;</td>
				<td></td>
			</tr>
			<tr>
				<td><label>Email</label><a class="star">*</a></td>
				<td><input type="text" class = "form-control input"  v-model="patientDTO.email"/></td><br/>
			</tr>
			<tr><td>&nbsp;</td>
				 <td align="left" style="color: red;font-size:12px">{{mailValidation}}</td>
			</tr>
			<tr>
				<td><label>Password</label><a class="star">*</a></td>
				<td><input type="password" class = "form-control input"  v-model="patientDTO.password"/></td><br/>
			</tr>
			<tr><td><hr></td>
				<td><hr></td></tr>
			</td>
			<tr>
				<td><label>Gender</label><a class="star">*</a></td>
				<td><select class="combo form-control input" v-model="patientDTO.gender">
					<option>Male</option>
					<option>Female</option>
				</select></td><br/>
			</tr>
			<tr>
				<td>&nbsp;</td>
				<td></td>
			</tr>
			<tr>
				<td><label>Health insurance number</label><a class="star">*</a></td>
				<td><input type="number" class = "form-control input"  v-model="patientDTO.healthInsuranceNumber"/></td><br/>
			</tr>
			<tr>
				<td>&nbsp;</td>
				<td></td>
			</tr>
			<tr>
				<td><label>Family diseases</label></td>
				<td><input type="text" class = "form-control input"  v-model="patientDTO.familyDiseases"/></td><br/>
			</tr>
			<tr>
				<td>&nbsp;</td>
				<td></td>
			</tr>
			<tr>
				<td><label>Personal diseases</label></td>
				<td><input type="text" class = "form-control input"  v-model="patientDTO.personalDiseases"/></td><br/>
			</tr>
			<tr>
				<td>&nbsp;</td>
				<td></td>
			</tr>
			<tr>
                 <td></td>
                <td align="left"><input type="file" accept="image/*" @change=uploadImage></td>

               </tr>
                <td align="left">Image:</td>
                <td><img  :src = "patientDTO.image" class = "form-control inputImage" style = "display:flex" width="100" heigh="50" /></td>
                <tr>
            </tr>
			</table>
			<button  type="button" class="btn2 btn-info btn-lg margin1" data-toggle="modal" data-target="#registrationInfo" v-on:click="AddPatient(patientDTO)" >Submit</button>
			<br/>
			<br/>



			








			<!-- Modal -->
			<div class="modal fade" id="registrationInfo" tabindex="-1" role="dialog" aria-labelledby="exampleModalScrollableTitle" aria-hidden="true">
			  <div class="modal-dialog modal-dialog-scrollable" role="document">
				<div class="modal-content">
				  <div class="modal-header">
					<h5 class="modal-title" id="exampleModalScrollableTitle">Registration info</h5>
					<button type="button" class="close" data-dismiss="modal" aria-label="Close">
					  <span aria-hidden="true">&times;</span>
					</button>
				  </div>
				  <div class="modal-body">
							<div class="input-group mb-3">
							  <div class="input-group-prepend">
								<span class="input-group-text width" id="basic-addon3">Name</span>
							  </div>
							  <input type="text"  v-model="patientDTO.name" class="form-control" id="basic-url" aria-describedby="basic-addon3" disabled>
						</div>

							<div class="input-group mb-3">
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
						</div>

							<div class="input-group mb-3">
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
						</div>

							<div class="input-group mb-3">
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
						</div>

							<div class="input-group mb-3">
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
						</div>

							<div class="input-group mb-3">
							  <div class="input-group-prepend ">
								<span class="input-group-text width" id="basic-addon3">Address</span>
							  </div>
							  <input type="text"  v-model="patientDTO.address" class="form-control" id="basic-url" aria-describedby="basic-addon3" disabled>
						</div>

							<div class="input-group mb-3">
							  <div class="input-group-prepend">
								<span class="input-group-text width" id="basic-addon3">Place of residence</span>
							  </div>
							  <input type="text"  v-model="patientDTO.placeOfResidence" class="form-control" id="basic-url" aria-describedby="basic-addon3" disabled>
						</div>

							<div class="input-group mb-3">
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
						</div>

							<div class="input-group mb-3">
							  <div class="input-group-prepend">
								<span class="input-group-text width" id="basic-addon3">Profesion</span>
							  </div>
							  <input type="text"  v-model="patientDTO.profesion" class="form-control" id="basic-url" aria-describedby="basic-addon3" disabled>
						</div>

							<div class="input-group mb-3">
							  <div class="input-group-prepend">
								<span class="input-group-text width" id="basic-addon3">Employment status</span>
							  </div>
							  <input type="text"  v-model="patientDTO.employmentStatus" class="form-control" id="basic-url" aria-describedby="basic-addon3" disabled>
						</div>

							<div class="input-group mb-3">
							  <div class="input-group-prepend">
								<span class="input-group-text width" id="basic-addon3">Marital status</span>
							  </div>
							  <input type="text"  v-model="patientDTO.maritalStatus" class="form-control" id="basic-url" aria-describedby="basic-addon3" disabled>
						</div>

							<div class="input-group mb-3">
							  <div class="input-group-prepend">
								<span class="input-group-text width" id="basic-addon3">Contact number</span>
							  </div>
							  <input type="text"  v-model="patientDTO.contactNumber" class="form-control" id="basic-url" aria-describedby="basic-addon3" disabled>
						</div>

							<div class="input-group mb-3">
							  <div class="input-group-prepend">
								<span class="input-group-text width" id="basic-addon3">Email</span>
							  </div>
							  <input type="text"  v-model="patientDTO.email" class="form-control" id="basic-url" aria-describedby="basic-addon3" disabled>
						</div>

							<div class="input-group mb-3">
							  <div class="input-group-prepend">
								<span class="input-group-text width" id="basic-addon3">Password</span>
							  </div>
							  <input type="text"  v-model="patientDTO.password" class="form-control" id="basic-url" aria-describedby="basic-addon3" disabled>
						</div>

							<div class="input-group mb-3">
							  <div class="input-group-prepend">
								<span class="input-group-text width" id="basic-addon3">Gender</span>
							  </div>
							  <input type="text"  v-model="patientDTO.gender" class="form-control" id="basic-url" aria-describedby="basic-addon3" disabled>
						</div>

							<div class="input-group mb-3">
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
						</div>

							<div class="input-group mb-3">
							  <div class="input-group-prepend">
								<span class="input-group-text width" id="basic-addon3">Personal diseases</span>
							  </div>
							  <input type="text"  v-model="patientDTO.personalDiseases" class="form-control" id="basic-url" aria-describedby="basic-addon3" disabled>
						</div>
				  </div>
				  <div class="modal-footer">
					<button type="button" class="btn btn-secondary" data-dismiss="modal">Close</button>
				  </div>
				</div>
			  </div>
			</div>













    </div>
	`,
	computed : {
		nameValidation: function () {
			if (this.patientDTO.name != undefined && this.patientDTO.name.length > 0) {
				let nameMatch = this.patientDTO.name.match('[A-Za-z ]*');
				if (nameMatch != this.patientDTO.name) return 'The name may contain only letters';
				else if (this.patientDTO.name[0].match('[A-Z]') === null) return 'The name must begin with a capital letter';
			}
			else if (this.patientDTO.name === '') return 'Name is a required field';
			else return null;
		},
		surnameValidation: function () {
			if (this.patientDTO.surname != undefined && this.patientDTO.surname.length > 0) {
				let surnameMatch = this.patientDTO.surname.match('[A-Za-z ]*');
				if (surnameMatch != this.patientDTO.surname) return 'The surname may contain only letters';
				else if (this.patientDTO.surname[0].match('[A-Z]') === null) return 'The surname must begin with a capital letter';
			}
			else if (this.patientDTO.surname === '') return 'Surname is a required field';
			else return null;
		},
		parentNameValidation: function () {
			if (this.patientDTO.parentName != undefined && this.patientDTO.parentName.length > 0) {
				let parentNameMatch = this.patientDTO.parentName.match('[A-Za-z ]*');
				if (parentNameMatch != this.patientDTO.parentName) return 'The parent name may contain only letters';
				else if (this.patientDTO.parentName[0].match('[A-Z]') === null) return 'The parent name must begin with a capital letter';
			}
			else if (this.patientDTO.parentName === '') return 'Parent name is a required field';
			else return null;
		},
		mailValidation: function () {
			if (this.patientDTO.email != undefined && this.patientDTO.email.length > 0) {
				let mailMatch = this.patientDTO.email.match("^[a-zA-Z0-9.!#$%&'*+/=?^_`{|}~-]+@[a-zA-Z0-9-]+(?:\.[a-zA-Z0-9-]+)*$");
				if (mailMatch != this.patientDTO.email) return 'Not a good form of mail';
			}
			else if (this.patientDTO.email === '') return 'Mail name is a required field';
			else return null;
		},
    },
	methods: {
		uploadImage(e) {
			const previewImage = e.target.files[0];
			const reader = new FileReader();
			reader.readAsDataURL(previewImage);
			reader.onload = e => {
				this.patientDTO.image = e.target.result;
			};
		},
		AddPatient: function (patientDTO) {
			if (patientDTO.name != null && patientDTO.surname != null && patientDTO.parentName != null && patientDTO.id != null
				&& patientDTO.dateOfBirth != null && patientDTO.placeOfBirth != null && patientDTO.municipalityOfBirth != null && patientDTO.stateOfBirth != null
				&& patientDTO.nationality != null && patientDTO.citizenship != null && patientDTO.address != null && patientDTO.placeOfResidence != null
				&& patientDTO.municipalityOfResidence != null && patientDTO.stateOfResidence != null && patientDTO.profession != null && patientDTO.employmentStatus != null
				&& patientDTO.maritalStatus != null && patientDTO.contact != null && patientDTO.email != null && patientDTO.password != null
				&& patientDTO.gender != null && patientDTO.healthInsuranceNumber != null) {
				axios
					.post("http://localhost:49900/registration/registerPatient", patientDTO)
					.then(response => {
						//this.$modal.show('registrationInfo');
					})

					.catch(error => {
						
						alert("Person with that unique citizens identity number already already exists.");
					})
			}
			else {
				alert("All fields are required.");

			}
		},
	},
});