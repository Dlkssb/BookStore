$(document).ready(function() {
    fillTable();


    $('#search-book').on('input', function() {
        var searchValue = $(this).val();
        filterTable(searchValue);
      });


      // Add event listener to the edit button in the table
$('#book-list').on('click', '.edit-btn', function() {
    // Get the book ID from the data attribute
    const bookId = $(this).data('id');
    // Invoke the update function with the book ID
    updateBook(bookId);
  });


  $('#book-list').on('click', '.delete-book', function() {
    var row = $(this).closest('tr');
    var bookId = row.find('.book-id').text();
    deleteBook(bookId, row);
  });

  $('#add-book').click(addBook);




  function fillTable() {
    $.get('http://localhost:5018/api/books', function(data) {
      var bookList = $('#book-list');
      bookList.empty();
      data.forEach(function(book, index) {
        var row = '<tr>' +
          '<td>' + (index + 1) + '</td>' +
          '<td>' + book.name + '</td>' +
          '<td>' + book.author + '</td>' +
          '<td>' + book.year + '</td>' +
          '<td>' + book.rack + '</td>' +
          '<td>' + book.shelf + '</td>' +
          '<td>$' + book.price.toFixed(2) + '</td>' +
          '<td>' + (book.status ? 'Available' : 'Not Available') + '</td>' +
          '<td>' +
          '<button class="btn btn-sm btn-primary mr-1" onclick="editBook(' + book.id + ')">Edit</button>' +
          '<button class="btn btn-sm btn-danger" onclick="deleteBook(' + book.id + ')">Delete</button>' +
          '</td>' +
          '</tr>';
        bookList.append(row);
      });
    });
  }


  function filterTable(searchValue) {
    $('#book-list tr').each(function(index, row) {
      var bookName = $(row).find('td:eq(1)').text();
      if (bookName.toLowerCase().indexOf(searchValue.toLowerCase()) === -1) {
        $(row).hide();
      } else {
        $(row).show();
      }
    });
  }


  function updateBook(id) {
    // get the row of the book to update
    var row = $("#book-list").find("[data-id='" + id + "']");
    
    // get the input values
    var name = row.find(".book-name").val();
    var author = row.find(".book-author").val();
    var year = row.find(".book-year").val();
    var rack = row.find(".book-rack").val();
    var shelf = row.find(".book-shelf").val();
    var price = row.find(".book-price").val();
  
    // send PUT request to update book
    $.ajax({
      url: "http://localhost:5018/api/books/10/" + id,
      type: "PUT",
      data: {
        name: name,
        author: author,
        year: year,
        rack: rack,
        shelf: shelf,
        price: price
      },
      success: function(result) {
        // update the row with new data
        row.find(".book-name").html(name);
        row.find(".book-author").html(author);
        row.find(".book-year").html(year);
        row.find(".book-rack").html(rack);
        row.find(".book-shelf").html(shelf);
        row.find(".book-price").html(price);
        // show success message
        Swal.fire(
          'Book Updated',
          'The book has been successfully updated.',
          'success'
        );
      },
      error: function(xhr, textStatus, errorThrown) {
        // show error message
        Swal.fire(
          'Error!',
          'An error occurred while updating the book.',
          'error'
        );
      }
    });
  }


  function deleteBook(bookId, row) {
    $.ajax({
      url: 'http://localhost:5018/api/books/' + bookId,
      method: 'DELETE',
      success: function(result) {
        row.remove();
        Swal.fire({
          title: 'Book Deleted',
          icon: 'success'
        });
      },
      error: function(error) {
        console.log(error);
        Swal.fire({
          title: 'Error Deleting Book',
          text: error.responseJSON.message,
          icon: 'error'
        });
      }
    });
  }


  function addBook() {
    // Get input values
    const bookName = $('#book-name').val().trim();
    const author = $('#book-author').val().trim();
    const year = $('#book-year').val().trim();
    const rack = $('#book-rack').val().trim();
    const shelf = $('#book-shelf').val().trim();
    const price = Math.abs(parseFloat($('#book-price').val().trim()));
  
    // Validate input values
    if (!bookName || !author || !year || !rack || !shelf || isNaN(price)) {
      Swal.fire({
        icon: 'error',
        title: 'Oops...',
        text: 'Please fill in all fields with valid values!',
      });
      return;
    }
  
    $.ajax({
      url: "http://localhost:5018/api/books",
      type: "POST",
      data: {
        name: bookName,
        author: author,
        year: year,
        rack: rack,
        shelf: shelf,
        price: price
      },
      success: function(result) {

        fillTable();
        // show success message
        Swal.fire(
          'Book Added',
          'The book has been successfully Added.',
          'success'
        );
      },
      error: function(xhr, textStatus, errorThrown) {
        // show error message
        Swal.fire(
          'Error!',
          'An error occurred while Adding the book.',
          'error'
        );
      }
    });
  }


  });



  