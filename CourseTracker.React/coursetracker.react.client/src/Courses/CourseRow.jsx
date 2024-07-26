
const CourseRow = ({ course, editCourse }) => {

    const editCourseClick = (e) => {
        e.preventDefault();
        editCourse(course.id);
    };

    return (
        <tr>
            <td>
                <a href="" onClick={editCourseClick}>Edit</a>
            </td>
            <td>{course.name}</td>
            <td>{course.semester}</td>
            <td>{course.grade}</td>
        </tr>
    );

}

export default CourseRow;