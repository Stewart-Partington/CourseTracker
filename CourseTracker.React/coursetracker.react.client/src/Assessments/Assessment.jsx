import { useContext } from 'react';
import { navContext } from "../App";
import useAssessment from "../../Hooks/UseAssessment";
import Banner from "../Banner";
import AssessmentForm from "./AssessmentForm";

const Assessment = () => {

    const { navValues: navValues } = useContext(navContext);
    const { navigate } = useContext(navContext);
    const { navSetter } = useContext(navContext);
    const { assessment, setAssessment, saveAssessment, cancelAssessment, deleteAssessment, assessmentSaved, errors } = useAssessment(navValues, navigate, navSetter);

    const contents = assessment.id === undefined
        ?
        <Banner heading={navValues.Assessment.Name} />
        :
        <>
            <Banner heading={navValues.Assessment.Name} />
            <AssessmentForm key={assessment.id} assessment={assessment} setAssessment={setAssessment} saveAssessment={saveAssessment}
                cancelAssessment={cancelAssessment} deleteAssessment={deleteAssessment} assessmentSaved={assessmentSaved} errors={errors} />
            
        </>

    return (
        <div className="row">
            <div>
                {contents}
            </div>
        </div>
    );

};

export default Assessment;