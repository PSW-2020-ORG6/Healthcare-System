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



            specializationBack: 33,
            doctorBack: 33,
            dateTimeBack: 34,

            averageTime: 360,
            doctorMostWanted: "Doktor Doktorević",
            specializationMostWanted: "Cardiologist"

        }
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
                    <h3 class="fwd head">NO RETURNS</h3><h3 class="fwdP head" id = "blackText">{{step21percentsFWD}} %</h3>
                </div>
                <div class="sameLine">
                    <h3 class="bck head">ONE RETURN</h3><h3 class="bckP head" id = "blackText">{{step21percentsFSB}} %</h3>
                </div>
                <div class="sameLine">
                    <h3 class="quit head">MULTIPLE RETURNS</h3><h3 class="quitP head " id = "blackText">{{step21percentsBCK}} %</h3>
                </div>
                <div class="piechart" v-bind:style='{ backgroundImage: step21}'></div>
                <div id="text1">Specialization selection</div>
            </div>
            <div class="col-sm">
                <div class="sameLine">
                    <h3 class="fwd head">NO RETURNS</h3><h3 class="fwdP head" id = "blackText">{{step32percentsFWD}} %</h3>
                </div>
                <div class="sameLine">
                    <h3 class="bck head">ONE RETURN</h3><h3 class="bckP head" id = "blackText">{{step32percentsFSB}} %</h3>
                </div>
                <div class="sameLine">
                    <h3 class="quit head">MULTIPLE RETURNS</h3><h3 class="quitP head" id = "blackText">{{step32percentsBCK}} %</h3>
                </div>               
                <div class="piechart" v-bind:style='{ backgroundImage: step32}'></div>
            <div id="text1">Doctor selection</div>
            </div>
            <div class="col-sm">
                <div class="sameLine">
                    <h3 class="fwd head">NO RETURNS</h3><h3 class="fwdP head" id = "blackText">{{step43percentsFWD}} %</h3>
                </div>
                <div class="sameLine">
                    <h3 class="bck head">ONE RETURN</h3><h3 class="bckP head" id = "blackText">{{step43percentsFSB}} %</h3>
                </div>
                <div class="sameLine">
                    <h3 class="quit head">MULTIPLE RETURNS</h3><h3 class="quitP head" id = "blackText">{{step43percentsBCK}} %</h3>
                </div>                 <div class="piechart" v-bind:style='{ backgroundImage: step42}'></div>
                 <div id="text1">Appointment selection</div>
            </div>
          </div>

        <br><br>

        <h2 class="head">OVERALL</h2>
        <br>
        <div class="row">
            <div class="col-sm">
                <div class="sameLine">
                    <h3 class="fwd head">SPECIALIZATION</h3><h3 class="fwdP head" id = "blackText">{{specializationBack}} %</h3>
                </div>
                <div class="sameLine">
                    <h3 class="bck head">DOCTOR</h3><h3 class="bckP head" id = "blackText">{{doctorBack}} %</h3>
                </div>
                <div class="sameLine">
                    <h3 class="quit head">APPOINTMENTS</h3><h3 class="quitP head" id = "blackText">{{dateTimeBack}} %</h3>
                </div>
                <div class="piechart" v-bind:style='{ backgroundImage: step21}'></div>
                <div id="text1">Return percentage per step  </div>
            </div>
            <div class="col-sm">
                <div class="sameLine">
                    <h3 class="fwd head">SUCCESSFUL</h3><h3 class="fwdPAP head" id = "blackText">{{appointmentsPercentsSUCC}} %</h3>
                </div>
                <div class="sameLine">
                    <h3 class="quit head">GAVE UP</h3><h3 class="quitP head" id = "blackText">{{appointmentsPercentsQ}} %</h3>
                </div>  
                    <br>
                    <div class="piechart" v-bind:style='{ backgroundImage: appointments}'></div>
                    <div id="text1">Appointment reservation performance</div>
             </div>
             <div class="col-sm">
                     <h2 class="head">MOST WANTED</h2>
                    <hr>
                    <div class="sameLine">
                         <h3 id = "blackText" class="fwd head">SPECIALIZATION:</h3><h3 id = "blackText" class="noChart head">{{specializationMostWanted}} </h3>
                    </div>                 
                    <hr>
                    <div class="sameLine">
                         <h3 class="fwd head" id = "blackText">DOCTOR:</h3><h3 id = "blackText" class="noChart head">{{doctorMostWanted}} </h3>
                    </div>
                    <hr>
                    <h2 class="head">AVERAGE TIME SPENT CREATING APPOINTMENT</h2>
                    <div class="sameLine">
                         <h3 id = "blackText" class="avgTime head">{{averageTime}} sec</h3>
                    </div>
                 </div>
            </div>
       </div>

       <br><br>
	</div>
	`,
});