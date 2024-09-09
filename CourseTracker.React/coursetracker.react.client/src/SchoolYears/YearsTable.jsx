import useSchoolYears from "../../Hooks/UseSchoolYears";
import YearRow from "./YearRow";

const YearsTable = ({ studentId }) => {

    const { schoolYears, addSchoolYear, editSchoolYear, deleteSchoolYear } = useSchoolYears(studentId);

    const contents = 
        <>
            <section className="panel panel-default border p-3 mt-3">

                <div className="panel-heading">
                    <h3 className="panel-title">School Years</h3>
                </div>

                <div className="panel-body">

                    <div className="row mt-3">
                        <div className="col-md-12">
                            <button className="btn btn-primary" onClick={addSchoolYear}>
                                Add School Year
                            </button>
                        </div>
                    </div>

                    <div className="table-responsive">
                        <table id="tblSchoolYears" className="table table-striped">
                            <thead>
                                <tr>
                                    <th>&nbsp;</th>
                                    <th>Year #</th>
                                    <th>Year</th>
                                    <th>Average</th>
                                </tr>
                            </thead>
                            <tbody>
                                {
                                    schoolYears != undefined ? schoolYears.map(schoolYear => <YearRow key={schoolYear.id} schoolYear={schoolYear}
                                        editSchoolYear={editSchoolYear} deleteSchoolYear={deleteSchoolYear} />) : "<tr>loading...</tr>"
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

}

export default YearsTable;