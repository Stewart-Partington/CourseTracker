
const AttachmentRow = ({ attachment, editAttachment }) => {

    const editAttachmentClick = (e) => {
        e.preventDefault();
        editAttachment(attachment.id);
    };

    return (
        <tr>
            <td>
                <a href="" onClick={editAttachmentClick}>Download</a>
            </td>
            <td>{attachment.name}</td>
            <td>{attachment.type}</td>
        </tr>
    );

}

export default AttachmentRow;