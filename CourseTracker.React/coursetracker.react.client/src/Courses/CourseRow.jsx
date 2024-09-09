
const CourseRow = ({ course, editCourse, deleteCourse }) => {

    const editCourseClick = (e) => {
        e.preventDefault();
        editCourse(course.id);
    };

    const deleteCourseClick = (e) => {
        e.preventDefault();
        deleteCourse(course.id);
    }

    return (
        <tr>
            <td>
                <a href="" onClick={editCourseClick}>Edit</a>
                <a href="" onClick={deleteCourseClick} className="ms-1">Delete</a>
            </td>
            <td>{course.name}</td>
            <td>{course.semester}</td>
            <td>{course.grade}</td>
        </tr>
    );

}

export default CourseRow;