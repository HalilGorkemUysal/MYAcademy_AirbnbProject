
<script>
    (function () {
        "use strict";
    var form = document.getElementById("categoryForm");
    if (!form) return;

    var nameInput = form.querySelector('[name="CategoryName"]');
    var descInput = form.querySelector('[name="Description"]');
    var activeInput = document.getElementById("IsActive");
    var EMPTY_ICON = '<svg viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="1.8" stroke-linecap="round" stroke-dasharray="2 3"><circle cx="12" cy="12" r="8" /></svg>';

    function setText(el, value, placeholder) {
        el.textContent = value || placeholder;
    el.classList.toggle("cc-placeholder", !value);
        }

    function updateCounters() {
        document.querySelectorAll("[data-counter-for]").forEach(function (c) {
            var input = form.querySelector('[name="' + c.getAttribute("data-counter-for") + '"]');
            var max = Number(c.getAttribute("data-max"));
            var len = input.value.length;
            c.textContent = len + "/" + max;
            c.classList.toggle("is-near", len >= max * 0.9);
        });
        }

    function updatePreview() {
            var name = nameInput.value.trim();
    var desc = descInput.value.trim();
    document.querySelectorAll(".pv-name").forEach(function (el) {setText(el, name, "Kategori adı"); });
    setText(document.getElementById("pvDesc"), desc, "Açıklama eklenmedi");

    var checked = form.querySelector('input[name="Icon"]:checked');
    var svg = checked ? form.querySelector('label[for="' + checked.id + '"] svg').outerHTML : EMPTY_ICON;
    document.querySelectorAll(".pv-icon-slot").forEach(function (el) {el.innerHTML = svg; });

    var on = activeInput.checked;
    var badge = document.getElementById("pvStatus");
    badge.className = "badge " + (on ? "b-ok" : "b-done");
    badge.textContent = on ? "Aktif" : "Pasif";
    document.getElementById("activeTitle").textContent = on ? "Aktif" : "Pasif";
    document.getElementById("activeHint").textContent = on
    ? "Kategori misafirlere hemen gösterilir."
    : "Kategori kaydedilir ancak misafirlere gösterilmez.";

    updateCounters();
        }

    form.addEventListener("input", updatePreview);
    form.addEventListener("change", updatePreview);

    // Basit istemci doğrulaması (DTO'da [Required] yoksa da boş gönderimi engeller)
    form.addEventListener("submit", function (e) {
            var errors = [];
    if (!nameInput.value.trim()) errors.push({el: nameInput, msg: "Kategori adı zorunludur." });
    if (!form.querySelector('input[name="Icon"]:checked')) errors.push({el: form.querySelector('input[name="Icon"]'), msg: "Lütfen bir ikon seçin." });

    form.querySelectorAll(".cc-client-error").forEach(function (x) {x.remove(); });
    nameInput.classList.remove("input-validation-error");

    if (errors.length) {
        e.preventDefault();
    errors.forEach(function (err) {
                    var msg = document.createElement("span");
    msg.className = "field-validation-error cc-client-error";
    msg.textContent = err.msg;
    if (err.el === nameInput) {
        nameInput.classList.add("input-validation-error");
    nameInput.closest(".cc-field").querySelector(".cc-hint-row").prepend(msg);
                    } else {
        msg.style.display = "block"; msg.style.marginTop = "8px";
    form.querySelector(".cc-icons").after(msg);
                    }
                });
    errors[0].el.focus();
    return;
            }
    // Çift gönderimi engelle
    var btn = document.getElementById("saveBtn");
    btn.disabled = true;
    btn.lastChild.textContent = " Kaydediliyor…";
        });

    updatePreview();
    })();
</script>