import useAttachments from "../../Hooks/UseAttachments";
import { useContext } from 'react';
import { navContext } from "../App";

const AttachmentsTable = ({ assessmentId }) => {

    const { navValues: navValues } = useContext(navContext);
    const { attachments, setAttachments, addAttachment, editAttachment } = useAttachments(assessmentId, navValues); 

    function handleInputChange(e) {       
        setAttachments(e.target.files[0]);
    }

    function handleSubmit(e) {
        e.preventDefault();
        addAttachment(e);
    }

    const contents =
        <>
            <section className="panel panel-default border p-3 mt-3 row">

                <div className="panel-heading">
                    <h3 className="panel-title">Attachments</h3>
                </div>

                <div className="panel-body">

                    <div className="row mt-3">
                        <div className="col-md-12">

                            <form onSubmit={handleSubmit}>
                                <input type="file" onChange={ handleInputChange } />
                                <button type="submit">Upload</button>
                            </form>

                            {/*<button className="btn btn-primary" onClick={addAttachment}>*/}
                            {/*    Add Attachment*/}
                            {/*</button>*/}
                        </div>
                    </div>

                    {/*<div className="table-responsive">*/}
                    {/*    <table id="tblAssessments" className="table table-striped">*/}
                    {/*        <thead>*/}
                    {/*            <tr>*/}
                    {/*                <th>&nbsp;</th>*/}
                    {/*                <th>Name</th>*/}
                    {/*                <th>Type</th>*/}
                    {/*            </tr>*/}
                    {/*        </thead>*/}
                    {/*        <tbody>*/}
                    {/*            */}{/*{*/}
                    {/*            */}{/*    assessments != undefined ? assessments.map(assessment => <AssessmentRow key={assessment.id} assessment={assessment} editAssessment={editAssessment} />) : "<tr>loading...</tr>"*/}
                    {/*            */}{/*}*/}
                    {/*        </tbody>*/}
                    {/*    </table>*/}
                    {/*</div>*/}

                </div>

            </section>

        </>

    return (
        <div className="row">
            <div>
                {contents}
            </div>
        </div>
    );

};

export default AttachmentsTable;