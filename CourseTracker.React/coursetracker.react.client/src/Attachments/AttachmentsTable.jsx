import useAttachments from "../../Hooks/UseAttachments";
import { useContext } from 'react';
import { navContext } from "../App";
import AttachmentRow from "./AttachmentRow";

const AttachmentsTable = ({ assessmentId }) => {

    const { navValues: navValues } = useContext(navContext);
    const { attachments, setAttachment, addAttachment, deleteAttachment } = useAttachments(assessmentId, navValues); 

    function handleInputChange(e) {       
        setAttachment(e.target.files[0]);
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
                                <div>
                                    <input type="file" onChange={handleInputChange} />
                                </div>
                                <div className="mt-3">
                                    <button type="submit" className="btn btn-primary">Upload</button>
                                </div>
                            </form>
                        </div>
                    </div>

                    <div className="table-responsive">
                        <table id="tblAttachments" className="table table-striped">
                            <thead>
                                <tr>
                                    <th>&nbsp;</th>
                                    <th>Name</th>
                                    <th>Type</th>
                                </tr>
                            </thead>
                            <tbody>
                                {
                                    attachments != undefined ? attachments.map(attachment => <AttachmentRow key={attachment.id} attachment={attachment}
                                        deleteAttachment={deleteAttachment} navValues={navValues} />) : "<tr>loading...</tr>"
                                }
                            </tbody>
                        </table>
                    </div>

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