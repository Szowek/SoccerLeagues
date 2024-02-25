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
});

function displayMatches(matches) {
    $('#matches-container').empty();

    if (matches && matches.length > 0) {
        var table = $('<table class="table"></table>');
        var headerRow = $('<thead><tr><th>Wynik</th><th>Przeciwna drużyna</th><th>Punkty</th></tr></thead>');
        table.append(headerRow);

        var tbody = $('<tbody></tbody>');
        matches.forEach(function (match) {
            var row = $('<tr><td>' + match.result + '</td><td>' + match.opponent + '</td><td>' + match.score + '</td></tr>');
            tbody.append(row);
        });

        table.append(tbody);
        $('#matches-container').append(table);
    } else {
        $('#matches-container').append('<p>Brak meczów dla wybranej drużyny.</p>');
    }
}