$(document).ready(function () {
    $('button.show-matches').click(function () {
        var teamName = $(this).data('teamname');

        $.ajax({
            url: '/Home/GetMatchesForTeam',
            type: 'GET',
            data: { teamName: teamName },
            success: function (matches) {
                displayMatches(matches);
            },
            error: function (xhr, status, error) {
                console.error(error);
            }
        });
    });

    $('.toggle-favorite').click(function () {
        var teamId = $(this).data('teamid');
        var button = $(this);

        $.ajax({
            url: '/FavoriteTeams/ToggleFavorite',
            type: 'POST',
            data: { teamId: teamId },
            success: function (isFavorite) {
                if (isFavorite) {
                    $('.toggle-favorite[data-teamid=' + teamId + ']').removeClass('btn-success').addClass('btn-danger').text('Usuń z ulubionych');
                } else {
                    $('.toggle-favorite[data-teamid=' + teamId + ']').removeClass('btn-danger').addClass('btn-success').text('Do ulubionych');
                }
                updateButtonAppearance(button);
            },
            error: function (xhr, status, error) {
                console.error(error);
            }
        });
    });
});

function displayMatches(matches) {
    $('#matches-container').empty();

    if (matches && matches.length > 0) {
        var table = $('<table class="table"></table>');
        var headerRow = $('<thead><tr><th>Wynik</th><th>Drużyna przeciwna</th><th>Gole</th><th>Faza Ligowa</th></tr></thead>');
        table.append(headerRow);

        var tbody = $('<tbody></tbody>');
        matches.forEach(function (match) {
            var row = $('<tr><td>' + match.result + '</td><td>' + match.opponent + '</td><td>' + match.score + '</td><td>' + match.phaseName + '</td></tr>');
            tbody.append(row);
        });

        table.append(tbody);
        $('#matches-container').append(table);
    } else {
        $('#matches-container').append('<p>Brak meczów dla wybranej drużyny.</p>');
    }
}

function updateButtonAppearance(button) {
    var isFavorite = button.hasClass('favorite-team');
    console.log('Is favorite:', isFavorite);

    var buttonText = isFavorite ? 'Usuń z ulubionych' : 'Do ulubionych';
    var buttonClass = isFavorite ? 'btn-danger' : 'btn-success';

    console.log('Button text:', buttonText);
    console.log('Button class:', buttonClass);

    button.removeClass('btn-danger btn-success');
    button.addClass(buttonClass);
    button.text(buttonText);
    button.toggleClass('favorite-team');
    console.log('Button after update:', button);
}