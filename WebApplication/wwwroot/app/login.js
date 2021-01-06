﻿Vue.component("Login", {
	data: function () {
		return {
			usernameText: null,
			passwordText: null,
			loginResponse: null,
			token: null
		}
	},
	template: `
	<div id="Login">
		 <div class="loginbox">
			 <img src="../pictures/user.png" class="avatar">
				<h1>Login</h1>
					<form>
						<p>Username</p>
						<input type="text" name="" id="userNameId" placeholder="Enter Username" v-model="usernameText">
						<p>Password</p>
						<input type="password" name="" id="passwordId" placeholder="Enter Password" v-model="passwordText">
						<input type="button" name="" id="submitId" value="Login" v-on:click="Validation()">
						<a href="http://localhost:49900/#/registration">You don't have an account?</a>
					</form>
		</div>

					<div class="modal fade" id="myModal" role="dialog">
                        <div class="modal-dialog">
		                      <!-- Modal content-->
			                  <div class="modal-content">
					                <div class="modal-header">
								          <button type="button" class="close" data-dismiss="modal">&times;</button>
									</div>
							  <div class="modal-body">
                              <p>Please enter username.</p>
							 </div>
							 <div class="modal-footer">
                              <button type="button" class="btn btn-default" data-dismiss="modal" >Ok</button>
                             </div>
                          </div>
                        </div>
					</div>

					<div class="modal fade" id="myModal1" role="dialog">
                        <div class="modal-dialog">
		                      <!-- Modal content-->
			                  <div class="modal-content">
					                <div class="modal-header">
								          <button type="button" class="close" data-dismiss="modal">&times;</button>
									</div>
							  <div class="modal-body">
                              <p>Please enter password.</p>
							 </div>
							 <div class="modal-footer">
                              <button type="button" class="btn btn-default" data-dismiss="modal" >Ok</button>
                             </div>
                          </div>
                        </div>
					</div>

				<div class="modal fade" id="myModal2" role="dialog">
                        <div class="modal-dialog">
		                      <!-- Modal content-->
			                  <div class="modal-content">
					                <div class="modal-header">
								          <button type="button" class="close" data-dismiss="modal">&times;</button>
									</div>
							  <div class="modal-body">
                              <p>Wrong username or password.</p>
							 </div>
							 <div class="modal-footer">
                              <button type="button" class="btn btn-default" data-dismiss="modal" >Ok</button>
                             </div>
                          </div>
                        </div>
					</div>
	</div>
					
	`,
	methods: {
		Validation: function () {

			if (document.getElementById("userNameId").value === '') {
				$('#myModal').modal('show');
				//this.document.getElementById("submitId").disabled = true;
				return
			}
			else if (document.getElementById("passwordId").value === '') {
				$('#myModal1').modal('show');
				//	this.document.getElementById("submitId").disabled = true;
				return
			}
			else {
				this.Login()
				this.GetUserType(this.token)

			}
		},
		//Ova metoda ne radi nista ovde je samo u svrhe testiranja
		GetUserType: function (token) {
			axios.get('http://localhost:49900/login/GetUserType', {
				headers: {
					'Authorization': 'Bearer' + " " + token

				}
			})
				.then(response => {
					this.Redirect(response.data)
				})
		},
		Redirect: function (UserType) {
			if (UserType == "PATIENT") {
				this.$router.push('patient');
			}
			else {
				this.$router.push('admin');
			}
		},
		Login: function () {
			username = document.getElementById("userNameId").value
			password = document.getElementById("passwordId").value
			axios
				.get('http://localhost:49900/login/login', { params: { email: username, password: password } })
				.then(response => {
					this.token = response.data.token
					this.GetUserType(this.token)
					localStorage.setItem('token', this.token);


				})
				.catch(error => {
					alert("greska kod logina")
				})

		}
	},
});
