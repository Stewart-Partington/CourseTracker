
const AttachmentRow = ({ attachment, deleteAttachment, navValues }) => {

    const onDeleteClick = () => {
        deleteAttachment(attachment.id);
    }

    return (
        <tr>
            <td>
                <a href={'api/attachments/' + navValues.Assessment.Id + '/' + attachment.id}>Download</a>
                <a href="#" className="p-2" onClick={onDeleteClick}>Delete</a>
            </td>
            <td>{attachment.name}</td>
            <td>{attachment.type}</td>
        </tr>
    );

}

export default AttachmentRow;