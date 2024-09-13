import { useContext } from "react";
import { DeleteContext } from "./DeleteContext";

const DeleteModal = () => {

    const {
        modalShow,
        setModalShow,
        deleteRecord,
        //deleteUri,
        //setDeleteUri
    } = useContext(DeleteContext);

    const cssShowHide =
        modalShow && modalShow === true
            ? "modal show-modal has-backdrop"
            : "modal hide-modal";

    const value = {
        modalShow,
        setModalShow,
        deleteRecord,
        //deleteUri,
        //setDeleteUri
    };

    return (
        <>
            <style jsx>
                {`
          .show-modal {
            display: block;
          }

          .has-backdrop:before {
            content: "";
            background: rgb(24 26 29 / 77%);
            position: absolute;
            height: 100%;
            width: 100%;
            left: 0;
            top: 0;
            margin: 0;
            backdrop-filter: blur(5px);
          }

          .hide-modal {
            display: none;
          }
        `}
            </style>
            <div role="dialog" className={cssShowHide}>
                <div className="modal-dialog modal-dialog-centered">
                    <div
                        className="modal-content border-0"
                        style={{ backgroundColor: "#EEEEEE" }}
                    >
                        {/*<SpeakersModalHeader />*/}

                        <div className="modal-header bg-main-gradient text-white">
                            <h5 className="modal-title">
                                <span>Confirm Delete</span>
                            </h5>
                            <button
                                type="button"
                                onClick={() => {
                                    setModalShow(false);
                                }}
                                className="btn btn-sm text-dark"
                                data-dismiss="modal"
                                area-label="close"
                            >
                                <i className="fa fa-times"></i>
                            </button>
                        </div>

                        {/*<SpeakersModalBody />*/}

                        <div className="modal-body">
                            <div className="notes-box">
                                <div className="notes-content">
                                    <form>
                                        <div className="row">
                                            <div className="col-md-12">
                                                <div className="note-title">
                                                    <p>Are you sure you want to delete this record?</p>
                                                </div>
                                            </div>
                                        </div>
                                    </form>
                                </div>
                            </div>
                        </div>

                        {/*<SpeakersModalFooter />*/}

                        <div className="modal-footer justify-content-center">
                                <button
                                    onClick={() => {
                                        deleteRecord();
                                        setModalShow(false);
                                    }}
                                    className="float-left btn btn-accent"
                                >
                                    Delete
                                </button>

                            <button
                                className="btn btn-danger"
                                onClick={() => {
                                    setModalShow(false);
                                }}
                                data-dismiss="modal"
                            >
                                Cancel
                            </button>

                        </div>

                    </div>
                </div>
            </div>
        </>
    );

};

export default DeleteModal;