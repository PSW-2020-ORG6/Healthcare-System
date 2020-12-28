Vue.component("emailConfirmation", {
	data: function () {
		return {
			name: null,
		}
	},
	template: `
	<div class="confirmEmail">
		<h5>Please complete your registration by clicking this button</h5>
		<button v-on:click="Confirm(); SuccessfulRegistration();">Confirm</button>
		
	</div>
	`,
	methods: {
		Confirm: function () {
			var queryString = location.href
			var id = queryString.split("?");
			var id1 = id[1].split("=");
			axios
				.put("/registration/confirmationEmail/" + id1[1])
				.then(response => {
				})

				.catch(error => {
					alert(error);
				})
		},
		SuccessfulRegistration: function () {
			this.$router.push('successfulRegistration');
        }
	},
});