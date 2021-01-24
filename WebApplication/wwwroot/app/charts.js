Vue.component("charts", {
    data: function () {
        return {

            step21: "conic-gradient(Cornsilk 0,Cornsilk 38%,RosyBrown 38%,RosyBrown 61%,DarkGray 61%,DarkGray 100%)",
            step21percentsFWD: 38,
            step21percentsFSB: 23,
            step21percentsBCK: 39,

            step32: "conic-gradient(Cornsilk 0,Cornsilk 18%,RosyBrown 18%,RosyBrown 97%,DarkGray 97%,DarkGray 100%)",
            step32percentsFWD: 18,
            step32percentsFSB: 79,
            step32percentsBCK: 3,

            step42: "conic-gradient(Cornsilk 0,Cornsilk 32%,RosyBrown 32%,RosyBrown 65%,DarkGray 65%,DarkGray 100%)",
            step43percentsFWD: 32,
            step43percentsFSB: 33,
            step43percentsBCK: 35,

            appointments: "conic-gradient(Cornsilk 0,Cornsilk 38%,DarkGray 0,DarkGray 100%)",
            appointmentsPercentsSUCC: 38,
            appointmentsPercentsQ: 62,



            specializationBack: 33,
            doctorBack: 33,
            dateTimeBack: 34,

            averageTime: 360,
            doctorMostWanted: "Doktor DoktoreviÄ‡",
            specializationMostWanted: "Cardiologist",
            eventStatisticDTO: {}
        }
    },
    beforeMount() {
        axios
            .get('/event/eventStatistic', {
                headers: {
                    'Authorization': 'Bearer' + " " + localStorage.getItem('token')
                }
            })
            .then(response => {
                this.eventStatisticDTO = response.data
            })
            .catch(error => {
            })
        this.step21percentsFWD = this.eventStatisticDTO.PercentTransitionsToFirstStepOnce
        this.step21percentsFSB = this.eventStatisticDTO.PercentTransitionsToFirstStepTwice
        this.step21percentsBCK = this.eventStatisticDTO.PercentTransitionsToFirstStepMore

        this.step32percentsFWD = this.eventStatisticDTO.PercentTransitionsToSecondStepOnce
        this.step32percentsFSB = this.eventStatisticDTO.PercentTransitionsToSecondStepTwice
        this.step32percentsBCK = this.eventStatisticDTO.PercentTransitionsToSecondStepMore

        this.step43percentsFWD = this.eventStatisticDTO.PercentTransitionsToThirdStepOnce
        this.step43percentsFSB = this.eventStatisticDTO.PercentTransitionsToThirdStepTwice
        this.step43percentsBCK = this.eventStatisticDTO.PercentTransitionsToThirdStepMore

        this.appointmentsPercentsSUCC = this.eventStatisticDTO.PercentIsAppointmentScheduled
        this.appointmentsPercentsQ = this.eventStatisticDTO.PercentIsNotAppointmentScheduled

        this.specializationBack = this.eventStatisticDTO.PercenttTransitionsToFirstStep
        this.doctorBack = this.eventStatisticDTO.PercenttTransitionsToSecondStep
        this.dateTimeBack = this.eventStatisticDTO.PercenttTransitionsToThirdStep

        this.averageTime = this.eventStatisticDTO.SchedulingDuration

    },
    template: `
	<div id = "charts">

    <!--KORACI-->
    <br><br>
    <div class="container">
          <h2 class="head" >GOING BACK BY STEPS</h2>
          <br>
          <div class="row">
            <div class="col-sm">
                <div class="sameLine">
                    <h3 class="fwd head">NO RETURNS</h3><h3 class="fwdP head" id = "blackText">{{ this.eventStatisticDTO.percentTransitionsToFirstStepZero}} %</h3>
                </div>
                <div class="sameLine">
                    <h3 class="bck head">ONE RETURN</h3><h3 class="bckP head" id = "blackText">{{ this.eventStatisticDTO.percentTransitionsToFirstStepOnce}} %</h3>
                </div>
                <div class="sameLine">
                    <h3 class="quit head">MULTIPLE RETURNS</h3><h3 class="quitP head " id = "blackText">{{ this.eventStatisticDTO.percentTransitionsToFirstStepMore}} %</h3>
                </div>
                <div class="piechart" v-bind:style='{ backgroundImage: step21}'></div>
                <div id="text1">Date selection</div>
            </div>
            <div class="col-sm">
                <div class="sameLine">
                    <h3 class="fwd head">NO RETURNS</h3><h3 class="fwdP head" id = "blackText">{{this.eventStatisticDTO.percentTransitionsToSecondStepZero}} %</h3>
                </div>
                <div class="sameLine">
                    <h3 class="bck head">ONE RETURN</h3><h3 class="bckP head" id = "blackText">{{this.eventStatisticDTO.percentTransitionsToSecondStepOnce}} %</h3>
                </div>
                <div class="sameLine">
                    <h3 class="quit head">MULTIPLE RETURNS</h3><h3 class="quitP head" id = "blackText">{{this.eventStatisticDTO.percentTransitionsToSecondStepMore}} %</h3>
                </div>               
                <div class="piechart" v-bind:style='{ backgroundImage: step32}'></div>
            <div id="text1">Specialization selection</div>
            </div>
            <div class="col-sm">
                <div class="sameLine">
                    <h3 class="fwd head">NO RETURNS</h3><h3 class="fwdP head" id = "blackText">{{this.eventStatisticDTO.percentTransitionsToThirdStepZero}} %</h3>
                </div>
                <div class="sameLine">
                    <h3 class="bck head">ONE RETURN</h3><h3 class="bckP head" id = "blackText">{{this.eventStatisticDTO.percentTransitionsToThirdStepOnce}} %</h3>
                </div>
                <div class="sameLine">
                    <h3 class="quit head">MULTIPLE RETURNS</h3><h3 class="quitP head" id = "blackText">{{this.eventStatisticDTO.percentTransitionsToThirdStepMore}} %</h3>
                </div>                 <div class="piechart" v-bind:style='{ backgroundImage: step42}'></div>
                 <div id="text1">Doctor selection</div>
            </div>
          </div>

        <br><br>

        <h2 class="head">OVERALL</h2>
        <br>
        <div class="row">
            <div class="col-sm">
                <div class="sameLine">
                    <h3 class="fwd head">DATE</h3><h3 class="fwdP head" id = "blackText">{{this.eventStatisticDTO.percenttTransitionsToFirstStep}} %</h3>
                </div>                
                <div class="sameLine">
                    <h3 class="bck head">SPECIALIZATION</h3><h3 class="bckP head" id = "blackText">{{this.eventStatisticDTO.percenttTransitionsToSecondStep}} %</h3>
                </div>
                <div class="sameLine">
                    <h3 class="quit head">DOCTOR</h3><h3 class="quitP head" id = "blackText">{{this.eventStatisticDTO.percenttTransitionsToThirdStep}} %</h3>
                </div>
                <div class="piechart" v-bind:style='{ backgroundImage: step21}'></div>
                <div id="text1">Return percentage per step  </div>
            </div>
            <div class="col-sm">
                <div class="sameLine">
                    <h3 class="fwd head">SUCCESSFUL</h3><h3 class="fwdPAP head" id = "blackText">{{this.eventStatisticDTO.percentIsAppointmentScheduled}} %</h3>
                </div>
                <div class="sameLine">
                    <h3 class="quit head">GAVE UP</h3><h3 class="quitP head" id = "blackText">{{this.eventStatisticDTO.percentIsNotAppointmentScheduled}} %</h3>
                </div>  
                    <br>
                    <div class="piechart" v-bind:style='{ backgroundImage: appointments}'></div>
                    <div id="text1">Appointment reservation performance</div>
             </div>
             <div class="col-sm">
                     <h2 class="head">MOST WANTED</h2>
                    <h2 class="head">AVERAGE TIME SPENT CREATING APPOINTMENT</h2>
                    <div class="sameLine">
                         <h3 id = "blackText" class="avgTime head">{{this.eventStatisticDTO.schedulingDuration}}</h3>
                    </div>
                 </div>
            </div>
       </div>

       <br><br>
	</div>
	`,
});
